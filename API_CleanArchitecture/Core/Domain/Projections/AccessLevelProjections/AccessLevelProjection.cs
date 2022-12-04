namespace Domain.Models.AccessLevelModels;

using Domain.Events.AccessLevelEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record AccessLevel
{
   

    public void Apply(AccessLevel_Created e)
    {
        Name = e.name;
        DuringScheduleId = e.scheduleId;
        ExceptScheduleId = e.exceptScheduleId;
    }

    public void Apply(AccessLevelDoor_Added e)
    {
        var ALDoor = AccessLevelDoor.Create
            (
             e.AccessLevelId,
             e.dto.DoorId,
             e.dto.ScheduleId,
             e.dto.ExceptScheduleId
            );
        AccessLevelDoors.Add(ALDoor);
    }

    public void Apply(AccessLevel_Updated e)
    {
        if (e.New.Name != default! && e.New.Name != Name)
             Name = e.New.Name;

        if (e.New.ScheduleId != default! && e.New.ScheduleId != DuringScheduleId)
            DuringScheduleId = e.New.ScheduleId;

        if (/*e.New.ExceptScheduleId != default! &&*/ e.New.ExceptScheduleId != ExceptScheduleId)
            ExceptScheduleId = e.New.ExceptScheduleId;

    }
}
