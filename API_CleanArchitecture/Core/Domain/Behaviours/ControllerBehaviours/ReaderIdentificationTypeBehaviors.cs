using Domain.Behaviours.ControllerBehaviours.Base;
using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

namespace Domain.Models.ControllerModels.DoorModels.ReaderModeds;
public partial record ReaderIdentificationType
{
    public static ReaderIdentificationType Create(long controllerId, IdentificationType identificationType, long? duringScheduleId, long? exceptScheduleId)
    {
        return new ReaderIdentificationType(controllerId, identificationType, duringScheduleId, exceptScheduleId);
    }


    public Deleted<ReaderIdentificationType> Delete()
    {
        var e = new ReaderIdenticationType_Deleted(this);
        RegisterEvent(e);
        return new Deleted<ReaderIdentificationType>(this, e);
    }

    public bool Update(ReaderIdentificationType_GetById_DTO dto)
    {
        bool detectChanges = false;
        ReaderIdentificationType_GetById_UpdateEventDTO oldValue = new ReaderIdentificationType_GetById_UpdateEventDTO();
        ReaderIdentificationType_GetById_UpdateEventDTO newValue = new ReaderIdentificationType_GetById_UpdateEventDTO
        {

        };

        if (!IdentificationType.Equals(dto.IdentificationType))
        {
            oldValue.IdentificationType = IdentificationType;
            newValue.IdentificationType = dto.IdentificationType;
            detectChanges = true;
        }
        if (!DuringScheduleId.Equals(dto.DuringScheduleId))
        {
            oldValue.DuringScheduleId = DuringScheduleId;
            newValue.DuringScheduleId = dto.DuringScheduleId;
            detectChanges = true;
        }
        if (!ExceptScheduleId.Equals(dto.ExceptScheduleId))
        {
            oldValue.ExceptScheduleId = ExceptScheduleId;
            newValue.ExceptScheduleId = dto.ExceptScheduleId;
            detectChanges = true;
        }
        if (detectChanges)
        {
            var e = new ReaderIdentificationType_Updated(dto.Id, oldValue, newValue);
            RegisterEvent(e);
        }

        return detectChanges;
    }
}
