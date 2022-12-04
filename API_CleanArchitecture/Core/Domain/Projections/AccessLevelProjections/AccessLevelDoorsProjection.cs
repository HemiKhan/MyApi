namespace Domain.Models.AccessLevelModels;

using Domain.Dtos.AccessLevelDTOs;
using Domain.Events.AccessLevelEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessLevelDoor
{
    protected override void When(IDomainEvent @event)
    {
        switch(@event) 
        {
            case AccessLevelDoor_Created e:
                Apply(e);
                break;
            case AccessLevelDoor_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    public void Apply(AccessLevelDoor_Created e)
    {
        DoorId = e.DoorId;
        AccessLevelId = e.AccessLevelId;
        DuringScheduleId = e.ScheduleId;
        ExceptScheduleId = e.ExceptScheduleId;
    }

    public void Apply(AccessLevelDoor_Updated e)
    {
        if(e.NewValue.DoorId != default! && e.NewValue.DoorId != DoorId)
            DoorId = e.NewValue.DoorId;

        if (e.AccessLevelId != default! && e.NewValue.AccessLevelId != AccessLevelId)
            AccessLevelId = e.AccessLevelId;

        if (e.NewValue.ScheduleId != default! && e.NewValue.ScheduleId != DuringScheduleId)
            DuringScheduleId = e.NewValue.ScheduleId;

        if (/*e.NewValue.ExceptScheduleId != default! &&*/ e.NewValue.ExceptScheduleId != ExceptScheduleId)
            ExceptScheduleId = e.NewValue.ExceptScheduleId;
    }
}
