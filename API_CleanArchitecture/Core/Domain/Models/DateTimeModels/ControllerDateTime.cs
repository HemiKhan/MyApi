namespace Domain.Models.TimeZoneModels;

using Domain.Constants;
using Domain.Events.ControllerEvents;
using Domain.Events.DateTimeSettingEvent;
using Domain.Models.ControllerModels;
using SharedKernel.Interfaces;

//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

using System.Net.Mail;

using System.Xml.Linq;

public partial record ControllerDateTime : AggregateRoot<long>, IMustHaveOrganization
{
    ControllerDateTime() { }
    ControllerDateTime(long controllerId, string timeZoneValue, bool dayLightSaving, SetMode setMode, string? dHCP, string? ipAddress, string? date, string? time)
    {
        var e = new DateTimeSetting_Added(controllerId, timeZoneValue, dayLightSaving, setMode, dHCP, ipAddress, date, time);
        RegisterEvent(e);
    }
    public long OrganizationId { get; set; }
    public long ControllerId { get; set; }
    public virtual Controller Controller { get; set; } = default!;
    public string TimeZoneValue { get; set; } = default!;
    public bool DayLightSaving { get; set; }
    public SetMode SetMode { get; set; }
    public string? DHCP { get; set; }
    public string? IPAddress { get; set; }
    public string? Date { get; set; }
    public string? Time { get; set; }
}
