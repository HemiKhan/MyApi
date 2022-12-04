namespace Domain.Events.DoorGroupEvent;

using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.DoorGroupDtos;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Models.DoorGroupModels;
using Domain.Models.ScheduleModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record DoorGroup_Added(string Name) : IDomainEvent;
public record DoorGroupDoor_Added(long DoorGroupId, long DoorId) : IDomainEvent;
public record DoorGroupDoor_Updated(long? Id, DoorGroupDoor_UpdateEventParameters Old, DoorGroupDoor_UpdateEventParameters New) : IDomainEvent;
public record DoorGroup_Updated(long Id, DoorGroup_UpdateEventParameters Old, DoorGroup_UpdateEventParameters New) : IDomainEvent;
public record DoorGroup_Deleted(DoorGroup DoorGroup) : IDeleteDomainEvent;

public class DoorGroup_UpdateEventParameters
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public DGDDto DGD { get; set; } = default!;
}
public class DoorGroupDoor_UpdateEventParameters
{
    public long Id { get; set; }
    public long DoorGroupId { get; set; }
    public long DoorId { get; set; }
}