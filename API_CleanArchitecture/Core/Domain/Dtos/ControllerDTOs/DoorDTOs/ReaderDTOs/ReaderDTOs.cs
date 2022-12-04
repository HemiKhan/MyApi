namespace Domain.Dtos.ReaderDTOs
{
    using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;

    public record AddReaderDTO(
        LEDType? LEDType,
        ReaderProtocol Protocol,
        string Name,
        string? Description,
        long? AreaInId,
        long? AreaOutId,
        string? Location,
        int HeartbeatInterval,
        int Timeout,
        string? LPNCameraSN,
        bool IsTimeAttendance,
        bool IsEnrollmentReader,
        ActiveType LEDActiveLevel,
        ActiveType TamperingType,
        ActiveType BeeperType,
        ReaderType ReaderType,
        AddReaderIdentificationTypeDTO[]? ReaderIdentificationType
    );

    public record UpdateReaderDTO(
        long? Id,
        long controllerId,
        long doorId,
        ReaderType ReaderType,
        ReaderProtocol Protocol,
        LEDType? LEDType,
        string Name,
        string Description,
        long? AreaInId,
        long? AreaOutId,
        string Location,
        int HeartbeatInterval,
        int Timeout,
        string LPNCameraSN,
        bool IsTimeAttendance,
        bool IsEnrollmentReader,
        ActiveType LEDActiveLevel,
        ActiveType TamperingType,
        ActiveType BeeperType,
        IEnumerable<UpdateReaderIdentificationTypeDTO> ReaderIdentificationType
    );

    public record Reader_GetById_DTO(
        long? Id,
        long controllerId,
        long doorId,
        ReaderType ReaderType,
        ReaderProtocol Protocol,
        LEDType? LEDType,
        string Name,
        string Description,
        long? AreaInId,
        long? AreaOutId,
        string Location,
        int HeartbeatInterval,
        int Timeout,
        string LPNCameraSN,
        bool IsTimeAttendance,
        bool IsEnrollmentReader,
        ActiveType LEDActiveLevel,
        ActiveType TamperingType,
        ActiveType BeeperType,
        IEnumerable<ReaderIdentificationType_GetById_DTO> ReaderIdentificationType
    );

    public record DeleteReaderDTO(long Id);
}
