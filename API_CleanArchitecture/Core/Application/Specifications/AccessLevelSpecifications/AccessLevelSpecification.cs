namespace Application.Specifications.AccessLevelSpecifications;

using Application.Handlers;
using Application.Specifications.Base;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Models.AccessLevelModels;
using Domain.Models.ControllerModels.DoorModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

internal static class AccessLevelSpecification
{
    internal static GenericQSpec<AccessLevel, object> GetAccessLevelForNameValidationSpecs(string name)
    {
        return new GenericQSpec<AccessLevel, object>()
        {
            SpecificationFunc = _ => _.Select(x => new { x.Name }).Where(x => x.Name == name)
        };
    }


    internal static GetAllSpec<AccessLevel, GetAll_AccessLevel_DTO> GetAllAccessLevelSpecs(GetAllParams getAllParams)
    {
        return new GetAllSpec<AccessLevel, GetAll_AccessLevel_DTO>()
        {
            SearchValue = getAllParams.SearchValue,
            SearchExpression = _ => getAllParams.SearchValue != null ? _.Name.ToLower().Contains(getAllParams.SearchValue!.ToLower()) : _.OrganizationId == -1,   
            PageSize = getAllParams.PageSize,
            PageNumber = getAllParams.PageIndex,
            SelectExpression = _=> new GetAll_AccessLevel_DTO(_.Id, _.Name),
            OrderBy = _=> _.Name,
        };
    }

    internal static GenericQSpec<AccessLevel, GetById_AccessLevel_DTO> GetByIdAccessLevelSpecs(long Id)
    {
        return new()
        {
            SpecificationFunc = _ => _
            .Where(x => x.Id == Id)
            .Include(x => x.AccessLevelDoors)
            .ThenInclude(x=>x.Door)
            .Select(x => new GetById_AccessLevel_DTO(
            x.Id,
            x.Name,
            x.DuringScheduleId,
            x.ExceptScheduleId,
            x.AccessLevelDoors
            .Select(x => new
            GetAll_AccessLevelDoor_DTO(
            x.Id,
            x.DoorId,
            x.Door.Name,
            x.DuringScheduleId,
            x.ExceptScheduleId)).ToList()))
        };
    }

    internal static GenericQSpec<AccessLevel, object> NameValidationForUpdateSpecs(long Id,string Name)
    {
        return new()
        {
             SpecificationFunc = _ => _.Select(_ => new { _.Name, _.Id })
            .Where(x => x.Name.ToLower() == Name.ToLower() && x.Id != Id)
        };
    }


    internal static GenericQSpec<QUserAccessLevel, UserAccessLevelsDTO> GetAllQUserAccessLevelsByUserId(long Id)
    {
        return new GenericQSpec<QUserAccessLevel, UserAccessLevelsDTO>()
        {
            SpecificationFunc = _ => _.Where(x => x.QUserId == Id).Select(_ => new UserAccessLevelsDTO { AccessLevelId = _.AccessLevelId, Id = _.Id })
           
        };
    }
}
