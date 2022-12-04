namespace Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;

using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;

public record Reader_Created(
    long controllerId,
    long doorId,

    LEDType? LEDType,
    ReaderProtocol Protocol,

    string Name,
    string Description,
    long? AreaIn,
    long? AreaOut,
    string Location,
    int HeartbeatInterval,
    int Timeout,
    string LPNCameraSN,
    bool IsTimeAttendance,
    bool IsEnrollmentReader,
    ActiveType LEDActiveLevel,
    ActiveType TamperingType,
    ActiveType BeeperType,
    ReaderType ReaderType,
    AddReaderIdentificationTypeDTO[] ReaderIdentificationType
    ) : IDomainEvent;

public record Reader_Updated(long? Id, Reader_GetById_UpdateEventparametersDTO oldValue, Reader_GetById_UpdateEventparametersDTO newValue) : IDomainEvent;