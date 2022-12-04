namespace Application.Specifications.AccessConfigSpecsifications;

using Application.Handlers;
using Application.Specifications.Base;
using Domain.Dtos.AccessConfigDTOs;
using Domain.Models.AccessConfigsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class AccessConfigSpecs
{
    internal static GenericQSpec<AccessConfig, GetByConfigKey_AccessConfigsDTO> GetByConfigKeySpecs(string configKey)
    {
        return new()
        {
            SpecificationFunc = _ => _.Where(x => x.ConfigKey!.ToLower() == configKey.ToLower())
            .Select(x => new GetByConfigKey_AccessConfigsDTO()
            {
                Id = x.Id,
                ConfigValue = x.ConfigValue,
                ParentId = x.ParentId
            })
        };
    }
    internal static GetAllSpec<AccessConfig, GetByParentIdAccessConfigsDTO> GetByParentIdSpecs(GetAllParams param)
    {
        return new()
        {
            SearchValue = param.SearchValue,
            PageNumber = param.PageIndex,
            PageSize = param.PageSize,
            SearchExpression = _ => _.ParentId == long.Parse(param.SearchValue!),
            SelectExpression = _=> new GetByParentIdAccessConfigsDTO()
            {
                ConfigValue = _.ConfigKey,
                ParentId = _.ParentId,
                ConfigKey = _.ConfigKey,
                Id = _.Id,
            }
        };
    }

    internal static GenericQSpec<AccessConfig, GetParentIdByConfigKeyDTO> GetIdOfParentSpecs(string ConfigKeyOfParent, long ParentIdOfParent = 0)
    {
        return new()
        {
            SpecificationFunc = _ => _.Where(x => x.ConfigKey == ConfigKeyOfParent && x.ParentId == ParentIdOfParent)
            .Select(x=> new GetParentIdByConfigKeyDTO(){Id = x.Id  })
        };
    }
}
