namespace Domain.Models.ScheduleModels;
using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Events.ScheduleEvents;


public partial record ScheduleItem
{
    public static ScheduleItem Create(ScheduleItems_AddUpDate_Request command) => new ScheduleItem(
                     command.ScheduleId,
                     command.Summary!,
                     command.StartTime,
                     command.EndTime,
                     command.RecurrenceDays,
                     command.ItemDefinition,
                     command.IsAllday,
                     command.IsWeekly,
                     command.IsEndBy,
                     command.IsRecurrence,
                     command.StartDate,
                     command.EndDate,
                     command.EndBy
                     );
    public Deleted<ScheduleItem> Delete()
    {
        var e = new ScheduleItemInfo_Deleted(this);
        RegisterEvent(e);
        return new Deleted<ScheduleItem>(this, e);
    }
    public void Update(ScheduleItems_AddUpDate_Request dto)
    {
        var ev = new ScheduleItemInfo_Updated(dto.Id, dto.ScheduleId,
            dto.Summary!, dto.StartTime, dto.EndTime, dto.RecurrenceDays, dto.ItemDefinition, dto.IsAllday
            , dto.IsWeekly, dto.IsEndBy, dto.IsRecurrence, dto.StartDate, dto.EndDate, dto.EndBy
            );
        RegisterEvent(ev);
    }
}

