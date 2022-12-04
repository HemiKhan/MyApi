using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Events.ControllerEvents.DoorEvents;

namespace Domain.Models.ControllerModels.DoorModels.RexModels;
public partial record Rex
{
    public static Rex Create(ActiveType rexConnection, long rexDuringSchedule, long? rexExceptSchedule, bool isRexNotUnlockDoor, long doorId, RexType rexType)
    {
        var o = new Rex(
            rexConnection,
            rexDuringSchedule,
            rexExceptSchedule,
            isRexNotUnlockDoor,
            doorId,
            rexType
        );

        return o;
    }

    public Deleted<Rex> Delete()
    {
        var e = new Rex_Deleted(this);
        RegisterEvent(e);
        return new Deleted<Rex>(this, e);
    }

    public bool UpdateRex(Rex_GetById_DTO dto, long doorId)
    {
        bool hasChanges = false;
        Rex_GetById_UpdateEventparameters oldValue = new Rex_GetById_UpdateEventparameters();
        Rex_GetById_UpdateEventparameters newValue = new Rex_GetById_UpdateEventparameters();

        if (!RexConnection.Equals(dto.RexConnection))
        {
            oldValue.RexConnection = RexConnection;
            newValue.RexConnection = dto.RexConnection;
            hasChanges = true;
        }

        if (!RexDuringScheduleId.Equals(dto.RexDuringScheduleId))
        {
            oldValue.RexDuringScheduleId = RexDuringScheduleId;
            newValue.RexDuringScheduleId = dto.RexDuringScheduleId;
            hasChanges = true;
        }

        if (!RexExceptScheduleId.Equals(dto.RexExceptScheduleId))
        {
            oldValue.RexExceptScheduleId = RexExceptScheduleId;
            newValue.RexExceptScheduleId = dto.RexExceptScheduleId;
            hasChanges = true;
        }
        if (!IsRexNotUnlockDoor.Equals(dto.IsRexNotUnlockDoor))
        {
            oldValue.IsRexNotUnlockDoor = IsRexNotUnlockDoor;
            newValue.IsRexNotUnlockDoor = dto.IsRexNotUnlockDoor;
            hasChanges = true;
        }

        if (!DoorId.Equals(doorId))
        {
            oldValue.DoorId = DoorId;
            newValue.DoorId = doorId;
            hasChanges = true;
        }

        if (!RexType.Equals(dto.RexType))
        {
            oldValue.RexType = RexType;
            newValue.RexType = dto.RexType;
            hasChanges = true;
        }

        if (hasChanges)
        {
            var e = new Rex_Updated(dto.Id, oldValue, newValue);
            RegisterEvent(e);
        }



        return hasChanges;
    }
}
