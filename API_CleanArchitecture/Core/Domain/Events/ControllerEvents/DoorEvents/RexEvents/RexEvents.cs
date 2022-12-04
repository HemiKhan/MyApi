using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;

public record Rex_Created(
    ActiveType RexConnection,
     long RexDuringScheduleId,
     long? RexExceptScheduleId,
     bool IsRexNotUnlockDoor,
     long DoorId,
     RexType RexType) : IDomainEvent;

public record Rex_Updated(long? Id, Rex_GetById_UpdateEventparameters oldValue, Rex_GetById_UpdateEventparameters newValue) : IDomainEvent;