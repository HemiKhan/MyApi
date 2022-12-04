namespace Domain.Models.ScheduleModels;
using Domain.Events.CardFormatEvents;
using Domain.Events.ScheduleEvents;
using Domain.Models.CardFormatsModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

public partial record ScheduleItem
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                ScheduleItemInfo_Added e:
                Apply(e);
                break;
            case
                ScheduleItemInfo_Updated e:
                Apply(e);
                break;
            case
                ScheduleItemInfo_Deleted e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    public void Apply(ScheduleItemInfo_Added e)
    {
        ScheduleId = e.scheduleId;
        Summary = e.summary;
        StartTime = e.startTime!;
        EndTime = e.endTime!;
        IsRecurrence = e.isRecurrence;
        IsWeekly = e.isWeekly;
        IsAllDay = e.isAllDay;
        IsEndBy = e.isEndBy;
        RecurrenceDays = e.recurrenceDays!;
        StartDate = e.startDate;
        EndDate = e.endDate;
        EndBy = e.endBy;
        ItemDefinition = e.itemDefinition;
    }
    public void Apply(ScheduleItemInfo_Updated e)
    {
        Id = e.Id;
        ScheduleId = e.scheduleId;
        Summary = e.summary;
        StartTime = e.startTime!;
        EndTime = e.endTime!;
        IsRecurrence = e.isRecurrence;
        IsWeekly = e.isWeekly;
        IsAllDay = e.isAllDay;
        IsEndBy = e.isEndBy;
        RecurrenceDays = e.recurrenceDays!;
        StartDate = e.startDate;
        EndDate = e.endDate;
        EndBy = e.endBy;
        ItemDefinition = e.itemDefinition;
    }

    public void Apply(ScheduleItemInfo_Deleted e)
    {
        Id = e.scheduleItem.Id;
        ScheduleId = e.scheduleItem.ScheduleId;
        Summary = e.scheduleItem.Summary;
        StartTime = e.scheduleItem.StartTime;
        EndTime = e.scheduleItem.EndTime;
        IsRecurrence = e.scheduleItem.IsRecurrence;
        IsWeekly = e.scheduleItem.IsWeekly;
        IsAllDay = e.scheduleItem.IsAllDay;
        IsEndBy = e.scheduleItem.IsEndBy;
        RecurrenceDays = e.scheduleItem.RecurrenceDays;
        StartDate = e.scheduleItem.StartDate;
        EndDate = e.scheduleItem.EndDate;
        EndBy = e.scheduleItem.EndBy;
    }
}
