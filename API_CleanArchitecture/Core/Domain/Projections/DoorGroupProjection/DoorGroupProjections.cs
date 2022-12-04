namespace Domain.Models.DoorGroupModels;
using Domain.Events;
using Domain.Events.DoorGroupEvent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record DoorGroup
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                DoorGroup_Added e:
                Apply(e);
                break;
            case
                DoorGroup_Updated e:
                Apply(e);
                break;
            case
                DoorGroup_Deleted e:
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    private void Apply(DoorGroup_Added e)
    {
        Name = e.Name;
    }
    private void Apply(DoorGroup_Updated e)
    {
        if (e.New.Name != default && !e.New.Name.Equals(Name))
            Name = e.New.Name;
    }
}
