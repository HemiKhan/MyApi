namespace Domain.Models.DoorGroupModels;

using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.DoorGroupDtos;
using Domain.Events.DoorGroupEvent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial record DoorGroupDoors
{
    public static DoorGroupDoors Create(long DoorGroupId, long DoorId) => new DoorGroupDoors(
     DoorId, DoorGroupId
                    );


    public bool Update(DGDDto dto, long DGID)
    {
        bool hasChanges = false;
        DoorGroupDoor_UpdateEventParameters oldValue = new DoorGroupDoor_UpdateEventParameters();
        DoorGroupDoor_UpdateEventParameters newValue = new DoorGroupDoor_UpdateEventParameters();

        if (!DoorGroupId.Equals(DGID))
        {
            oldValue.DoorGroupId = DoorGroupId;
            newValue.DoorGroupId = DGID;
            hasChanges = true;
        }

        if (!DoorId.Equals(dto.DoorId))
        {
            oldValue.DoorId = DoorId;
            newValue.DoorId = dto.DoorId;
            hasChanges = true;
        }
        if (hasChanges)
        {
            var e = new DoorGroupDoor_Updated(dto.Id, oldValue, newValue);
            RegisterEvent(e);
        }
        return hasChanges;
    }
}
