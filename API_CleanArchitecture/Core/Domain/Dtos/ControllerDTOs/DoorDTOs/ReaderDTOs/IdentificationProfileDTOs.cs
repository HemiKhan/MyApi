namespace Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;


public record ReaderIdentificationTypeDTO
{
    public IdentificationType IdentificationType { get; set; }
    public long? DuringScheduleId { get; set; }
    public long? ExceptScheduleId { get; set; }
}

public record AddReaderIdentificationTypeDTO: ReaderIdentificationTypeDTO;

public record UpdateReaderIdentificationTypeDTO
    (
    long Id
    ) : ReaderIdentificationTypeDTO;

public record ReaderIdentificationType_GetById_DTO
    (
    long Id
    ): ReaderIdentificationTypeDTO;

public record DeleteReaderIdentificationTypeDTO(long Id);
