namespace Domain.Models.DoorGroupModels;

using Domain.Events.DoorGroupEvent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record DoorGroupDoors
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case DoorGroupDoor_Added e:
                Apply(e);
                break;
            case DoorGroupDoor_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }

    }

    private void Apply(DoorGroupDoor_Added e)
    {
        DoorGroupId = e.DoorGroupId;
        DoorId = e.DoorId;
    }
    private void Apply(DoorGroupDoor_Updated e)
    {
        if (e.New.DoorGroupId != default && e.New.DoorGroupId != DoorGroupId)
            DoorGroupId = e.New.DoorGroupId;
        if (e.New.DoorId != default && e.New.DoorId != DoorId)
            DoorId = e.New.DoorId;
    }
}