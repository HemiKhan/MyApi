namespace Domain.Dtos.Schedule.ScheduleItemsDtos;
public partial class ScheduleItems_AddUpDate_Request
{
    public long Id { get; set; }
    public long ScheduleId { get; set; }
    public string Summary { get; set; } = default!;
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public bool IsAllday { get; set; }
    public bool IsRecurrence { get; set; }
    public string? RecurrenceDays { get; set; }
    public bool IsWeekly { get; set; }
    public bool IsEndBy { get; set; }
    public string? ItemDefinition { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndBy { get; set; }
}