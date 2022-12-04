namespace Domain.Models.TimeZoneModels;

using Domain.Events.DateTimeSettingEvent;
using SharedKernel.Interfaces;

using System;

public partial record ControllerDateTime
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                DateTimeSetting_Added e:
                Apply(e);
                break;
            case
                DateTimeSetting_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    private void Apply(DateTimeSetting_Added e)
    {
        ControllerId = e.controllerId;
        TimeZoneValue = e.timeZoneValue;
        DayLightSaving = e.dayLightSaving;
        SetMode = e.setMode;
        Date = e.date;
        Time = e.time;
        DHCP = e.dHCP;
        IPAddress = e.ipAddress;
    }
    private void Apply(DateTimeSetting_Updated e)
    {
        ControllerId = e.controllerId;
        TimeZoneValue = e.timeZoneValue;
        DayLightSaving = e.dayLightSaving;
        SetMode = e.setMode;
        Date = e.date;
        Time = e.time;
        DHCP = e.dHCP;
        IPAddress = e.ipAddress;
    }
}
