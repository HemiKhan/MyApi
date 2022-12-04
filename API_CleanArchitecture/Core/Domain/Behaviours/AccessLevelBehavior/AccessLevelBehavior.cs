namespace Domain.Models.AccessLevelModels;

using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Events.AccessLevelEvents;

using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Behavior
public partial record AccessLevel
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case AccessLevelDoor_Added e:
                Apply(e);
                break;
            case AccessLevel_Created e:
                Apply(e);
                break;
            case AccessLevel_Updated e:
                Apply(e);
                break;
                case AccessLevel_Deleted e:
                break;
        }
    }
    public static AccessLevel Create(Add_AccessLevel_DTO command)
    {
        var accesslevel = new AccessLevel
            (
             command.Name,
             command.ScheduleId,
             command.ExceptScheduleId
            );
        accesslevel.AddAccessLevelDoors(command.AccessLevelDoors, accesslevel.Id);
        return accesslevel;
    }
    public Deleted<AccessLevel> Delete()
    {
        var e = new AccessLevel_Deleted(this);
        RegisterEvent(e);
        return new Deleted<AccessLevel>(this, e);
    }
    public void AddAccessLevelDoors(Add_AccessLevelDoor_DTO[] commands, long accessLevelId)
    {
        foreach (var command in commands)
        {
            var e = new AccessLevelDoor_Added(command, accessLevelId);
            RegisterEvent(e);
        }

    }
    public void Update(Update_AccessLevel_DTO dto)
    {
        var New = new Update_AccessLevel_Parameters();
        var Old = new Update_AccessLevel_Parameters();

        New.Id = Id;
        Old.Id = Id;

        if (!Name.Equals(dto.Name))
        {
            New.Name = dto.Name;
            Old.Name = Name;
        }
        if (!DuringScheduleId.Equals(dto.ScheduleId))
        {
            New.ScheduleId = dto.ScheduleId;
            Old.ScheduleId = DuringScheduleId;
        }

        if (!ExceptScheduleId.Equals(dto.ExceptScheduleId))
        {
            New.ExceptScheduleId = dto.ExceptScheduleId;
            Old.ExceptScheduleId = ExceptScheduleId;
        }
        UpdateAccessLevelDoors(dto.AccessLevelDoors.ToList());

        var e = new AccessLevel_Updated(Old, New);
        RegisterEvent(e);
    }
    public void UpdateAccessLevelDoors(List<Update_AccessLevelDoor_DTO> dto)
    {
        List<AccessLevelDoor> newAccessLevelDoors = new();
        List<AccessLevelDoor> deletedAccessLevelDoors = new();

        foreach (var b in AccessLevelDoors.ToList())
        {
            if (!dto.Any(c => c.Id == b.Id))
                AccessLevelDoors.Remove(b);
        }

        foreach (var item in dto)
        {
            var ExistingItem = AccessLevelDoors.FirstOrDefault(_ => _.Id == item.Id && _.AccessLevelId == Id);
            if ((!item.Id.Equals(null)) && ExistingItem == null)
                throw new QException($" Id '{item.Id}' Does Not Exists in Access Level Doors ");

            if (ExistingItem != null)
            {
                ExistingItem.Update(Id, item);
            }
            else
            {
                var @new = AccessLevelDoor.Create
                    (
                     Id,
                     item.DoorId,
                     item.ScheduleId,
                     item.ExceptScheduleId
                    );
                AccessLevelDoors.Add(@new);
            }

        }



    }

}
