namespace Domain.Dtos.Schedule.ScheduleItemsDtos;
public record AddScheduleItemDto(long ScheduleId, string Summary, string? StartTime, string? EndTime, string? RecurrenceDays, bool IsAllDay, bool IsRecurrence, bool IsWeekly, bool IsEndBy, DateTime StartDate, DateTime? EndDate, DateTime? EndBy);
public record UpdateScheduleItemDto(long Id, long ScheduleId, string Summary, string? StartTime, string? EndTime, string? RecurrenceDays, bool IsAllDay, bool IsRecurrence, bool IsWeekly, bool IsEndBy, DateTime StartDate, DateTime? EndDate, DateTime? EndBy);
public record GetScheduleItemDTO(long Id, long ScheduleId, string Summary, string? StartTime, string? EndTime, string? RecurrenceDays, bool IsAllDay, bool IsRecurrence, bool IsWeekly, bool IsEndBy, DateTime StartDate, DateTime? EndDate, DateTime? EndBy);
public record DeleteScheduleItemDto(long Id);
public record UpdateScheduleDefinitionDTO(long ScheduleId, string? Definition);
public record GetScheduleItemByScheduleDTO(long ScheduleId);
public record GetScheduleItemByIdDTO(long Id);
