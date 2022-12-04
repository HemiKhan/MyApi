namespace Domain.Models.AccessLevelModels;

using Domain.Dtos.AccessLevelDTOs;
using Domain.Events.AccessLevelEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Behavior
public partial record AccessLevelDoor
{
    public static AccessLevelDoor Create(long AccessLevelId, long DoorId, long ScheduleId, long? ExceptScheduleId)
    {
        return new AccessLevelDoor
            (
              AccessLevelId,
              DoorId,
              ScheduleId,
              ExceptScheduleId
            );
    }

    public void Update(long accessLevelId,Update_AccessLevelDoor_DTO dto)
    {
        Update_AccessLevelDoor_Parameters Old = new();
        Update_AccessLevelDoor_Parameters New = new();
        if (dto is null)
            return;

            Old.AccessLevelId = AccessLevelId;
            New.AccessLevelId = AccessLevelId;
            New.Id = dto.Id;

        if (!dto.DoorId.Equals(DoorId))
        {
            Old.DoorId = DoorId;
            New.DoorId = dto.DoorId;
        }

        if (!dto.ScheduleId.Equals(DuringScheduleId))
        {
            Old.ScheduleId = DuringScheduleId;
            New.ScheduleId = dto.ScheduleId;
        }

        if (!dto.ExceptScheduleId.Equals(ExceptScheduleId))
        {
            Old.ExceptScheduleId = ExceptScheduleId;
            New.ExceptScheduleId = dto.ExceptScheduleId;
        }
        var e = new AccessLevelDoor_Updated(accessLevelId,Old, New);
        RegisterEvent(e);
    }
}
