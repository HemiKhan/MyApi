namespace Application.ExtensionMethods.Mappings.ScheduleMappings;
using Domain.Dtos.Schedule.ScheduleItemsDtos;
using Domain.Models.ScheduleModels;

internal static class ScheduleItemDtoExtensionMethods
{
    public static GetScheduleItemDTO AsDomainModel(this ScheduleItem entity)
    {
        return new GetScheduleItemDTO(
           entity.Id,
           entity.ScheduleId,
           entity.Summary!,
           entity.StartTime,
           entity.EndTime,
           entity.RecurrenceDays,
           entity.IsAllDay,
           entity.IsRecurrence,
           entity.IsWeekly,
        entity.IsEndBy,
           entity.StartDate,
           entity.EndDate,
           entity.EndBy
            )
        {

        };
    }
}
