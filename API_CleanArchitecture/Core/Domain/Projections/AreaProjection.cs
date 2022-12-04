namespace Domain.Models;

using Domain.Events;

using System;

public partial record Area
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                Area_Added e:
                Apply(e);
                break;
            case
                AreaName_Updated e:
                Apply(e);
                break;
            case
                AreaEntrance_Updated e:
                Apply(e);
                break;
            case
                Area_Deleted e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    private void Apply(Area_Added e)
    {
        Name = e.name;
        IsEntrance = e.isEntrance;
    }
    private void Apply(AreaName_Updated e)
    {
        Name = e.New;
    }
    private void Apply(AreaEntrance_Updated e)
    {
        IsEntrance = e.New;
    }
    private void Apply(Area_Deleted e)
    {
        Id = e.area.Id;
        OrganizationId = e.area.OrganizationId;
        Name = e.area.Name;
        IsEntrance = e.area.IsEntrance;
    }
}
