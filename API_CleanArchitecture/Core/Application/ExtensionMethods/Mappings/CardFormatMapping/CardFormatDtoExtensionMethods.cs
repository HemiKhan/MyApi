namespace Application.ExtensionMethods.Mappings.CardFormatMapping;

using Domain.Dtos.CardFormatDtos;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.CardFormatsModels;
using Domain.Models.TimeZoneModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal static class CardFormatDtoExtensionMethods
{
    public static GetAllCardFormatsDto AsDomainModel(this CardFormat entity)
    {
        return new GetAllCardFormatsDto()
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
