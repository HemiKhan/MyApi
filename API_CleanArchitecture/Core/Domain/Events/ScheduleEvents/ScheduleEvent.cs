namespace Domain.Events.ScheduleEvents;

using Domain.Models.ScheduleModels;
using SharedKernel.Interfaces;

public record ScheduleInfo_Added(string Name, string Description, bool IsSubtraction) : IDomainEvent;
public record Schedule_Updated(long Id, UpdateScheduleEvents Old, UpdateScheduleEvents New) : IDomainEvent;
public record ScheduleDefinition_Updated(long Id, UpdateScheduleDefinitionEvents Old, UpdateScheduleDefinitionEvents New) : IDomainEvent;
public record Schedule_Deleted(Schedule schedule) : IDeleteDomainEvent;

public class UpdateScheduleEvents
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Definition { get; set; }
    public bool IsSubtraction { get; set; }
}
public class UpdateScheduleDefinitionEvents
{
    public long Id { get; set; }
    public string Definition { get; set; }
}