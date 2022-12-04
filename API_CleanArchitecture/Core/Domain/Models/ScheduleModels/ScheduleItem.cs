namespace Domain.Models.ScheduleModels
{
    using Domain.Events.ControllerEvents;
    using Domain.Events.ScheduleEvents;

    public partial record ScheduleItem : AggregateRoot<long>
    {

        ScheduleItem() { }
        ScheduleItem(long scheduleId, string summary, string? startTime, string? endTime, string? recurrenceDays, string? itemDefinition, bool isAllDay, bool isWeekly, bool isEndBy, bool isRecurrence, DateTime startDate, DateTime? endDate, DateTime? endBy)
        {
            var e = new ScheduleItemInfo_Added(scheduleId, summary, startTime, endTime, recurrenceDays, itemDefinition, isAllDay, isWeekly, isEndBy, isRecurrence, startDate, endDate, endBy);
            RegisterEvent(e);
        }
        public long ScheduleId { get; private set; }
        public Schedule Schedules { get; private set; } = default!;
        public string Summary { get; private set; } = default!;
        public string? StartTime { get; private set; } = default!;
        public string? EndTime { get; private set; } = default!;
        public string? RecurrenceDays { get; private set; } = default!;
        public string? ItemDefinition { get; private set; } = default!;
        public bool IsAllDay { get; private set; }
        public bool IsWeekly { get; set; }
        public bool IsEndBy { get; set; }
        public bool IsRecurrence { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; } = default!;
        public DateTime? EndBy { get; private set; } = default!;
    }
}


