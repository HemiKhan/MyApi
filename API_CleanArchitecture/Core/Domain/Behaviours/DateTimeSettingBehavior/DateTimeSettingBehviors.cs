namespace Domain.Models.TimeZoneModels;

using Domain.Dtos.TimeZoneSettingDtos;
using Domain.Events.DateTimeSettingEvent;

using System.Xml;

public partial record ControllerDateTime
{
    public static ControllerDateTime Create(AddControllerDateTimeSettingDto cmd) => new ControllerDateTime(
                    cmd.ControllerId,
                    cmd.TimeZoneValue,
                    cmd.DayLightSaving,
                    cmd.SetMode,
                    cmd.DHCP,
                    cmd.IPAddress,
                    cmd.Date,
                    cmd.Time);

    public void AddControllerDateTimeSetting(AddControllerDateTimeSettingDto dto)
    {
        var e = new DateTimeSetting_Added(dto.ControllerId, dto.TimeZoneValue, dto.DayLightSaving,
     dto.SetMode, dto.DHCP, dto.IPAddress, dto.Date, dto.Time
            );
        RegisterEvent(e);
    }
    public void UpdateControllerDateTimeSetting(UpdateControllerDateTimeSettingDto dto)
    {
        var e = new DateTimeSetting_Updated(dto.ControllerId, dto.TimeZoneValue, dto.DayLightSaving,
     dto.SetMode, dto.DHCP, dto.IPAddress, dto.Date, dto.Time
            );
        RegisterEvent(e);
    }
}