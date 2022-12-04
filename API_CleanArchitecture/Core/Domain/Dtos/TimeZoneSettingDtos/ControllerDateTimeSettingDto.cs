namespace Domain.Dtos.TimeZoneSettingDtos;
using Domain.Constants;

public class AddControllerDateTimeSettingDto
{
    public long ControllerId { get; set; }
    public string TimeZoneValue { get; set; }
    public bool DayLightSaving { get; set; }
    public SetMode SetMode { get; set; }
    public string? DHCP { get; set; }
    public string? IPAddress { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
}
public class UpdateControllerDateTimeSettingDto
{
    public long ControllerId { get; set; }
    public string TimeZoneValue { get; set; }
    public bool DayLightSaving { get; set; }
    public SetMode SetMode { get; set; }
    public string? DHCP { get; set; }
    public string? IPAddress { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
    public bool SettingForAllController { get; set; }
}
public class GetByIdDateTimeSettingDto
{
    public long ControllerId { get; set; }
    public string TimeZoneValue { get; set; }
    public bool DayLightSaving { get; set; }
    public SetMode SetMode { get; set; }
    public string? DHCP { get; set; }
    public string? IPAddress { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }

}

public class GetControllersListForDateTimeSetting
{
    public long? Id { get; set; }
    public string? Name { get; set; }
};
