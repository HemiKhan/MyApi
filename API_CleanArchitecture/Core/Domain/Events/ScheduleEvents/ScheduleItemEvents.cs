namespace Domain.Events.ScheduleEvents;

using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record ScheduleItemInfo_Added(long scheduleId, string summary, string? startTime, string? endTime, string? recurrenceDays, string? itemDefinition, bool isAllDay, bool isWeekly, bool isEndBy, bool isRecurrence, DateTime startDate, DateTime? endDate, DateTime? endBy) : IDomainEvent;
public record ScheduleItemInfo_Updated(long Id, long scheduleId, string summary, string? startTime, string? endTime, string? recurrenceDays, string? itemDefinition, bool isAllDay, bool isWeekly, bool isEndBy, bool isRecurrence, DateTime startDate, DateTime? endDate, DateTime? endBy) : IDomainEvent;
public record ScheduleItemInfo_Deleted(ScheduleItem scheduleItem) : IDeleteDomainEvent;