namespace Application.ExtensionMethods.Mappings.ControllerDateTimeSettingMapping;
using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Models.TimeZoneModels;

internal static class DateTimeDtoExtensionMethods
{
    public static GetByIdDateTimeSettingDto AsDomainModel(this ControllerDateTime entity)
    {
        return new GetByIdDateTimeSettingDto()
        {
            ControllerId = entity.ControllerId,
            TimeZoneValue = entity.TimeZoneValue,
            Time = entity.Time,
            Date = entity.Date,
            SetMode = entity.SetMode,
            DayLightSaving = entity.DayLightSaving,
            DHCP = entity.DHCP,
            IPAddress = entity.IPAddress
        };
    }
}
