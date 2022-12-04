namespace Domain.Models.ScheduleModels;
using Domain.Events.ScheduleEvents;

public partial record Schedule
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                ScheduleInfo_Added e:
                Apply(e);
                break;
            case
                Schedule_Updated e:
                Apply(e);
                break;
            case
                Schedule_Deleted e:
                Apply(e);
                break;
            case
                ScheduleDefinition_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }
    public void Apply(ScheduleInfo_Added e)
    {
        Name = e.Name;
        Description = e.Description;
        IsSubtraction = e.IsSubtraction;
    }
    public void Apply(Schedule_Updated e)
    {
        if (e.New.Name != default && e.New.Name != Name)
            Name = e.New.Name;
        if (e.New.Description != default && e.New.Description != Description)
            Description = e.New.Description;
        if (e.New.IsSubtraction != IsSubtraction)
            IsSubtraction = e.New.IsSubtraction;
    }
    public void Apply(Schedule_Deleted e)
    {
        Id = e.schedule.Id;
        Name = e.schedule.Name;
        Description = e.schedule.Description;
        Definition = e.schedule.Definition;
        IsSubtraction = e.schedule.IsSubtraction;
    }
    public void Apply(ScheduleDefinition_Updated e)
    {
        if (e.New.Definition != default && e.New.Definition != Definition)
            Definition = e.New.Definition;
    }
}
