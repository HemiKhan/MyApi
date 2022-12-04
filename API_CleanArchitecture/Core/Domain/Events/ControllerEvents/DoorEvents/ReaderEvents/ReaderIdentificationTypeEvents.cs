namespace Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;

public record ReaderIdentificationType_Added(long ControllerId, IdentificationType IdentificationType, long? DuringScheduleId, long? ExceptScheduleId) : IDomainEvent { }
public record ReaderIdentificationType_Updated(long Id, ReaderIdentificationType_GetById_UpdateEventDTO oldValue, ReaderIdentificationType_GetById_UpdateEventDTO newValue) : IDomainEvent { }
public record ReaderIdentificationType_Deleted(DeleteReaderIdentificationTypeDTO Value) : IDomainEvent { }


