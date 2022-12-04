namespace Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;


public record Rex_Add_DTO(
    ActiveType RexConnection,
    long RexDuringScheduleId,
    long? RexExceptScheduleId,
    bool IsRexNotUnlockDoor,
    RexType RexType
);

public record UpdateRexDTO(
    long? Id,
    ActiveType RexConnection,
    long RexDuringScheduleId,
    long? RexExceptScheduleId,
    bool IsRexNotUnlockDoor,
    RexType RexType
);

public record Rex_GetById_DTO(
    long? Id,
    ActiveType RexConnection,
    long RexDuringScheduleId,
    long? RexExceptScheduleId,
    bool IsRexNotUnlockDoor,
    RexType RexType
);

public record DeleteRexDTO(long Id);

public class Rex_GetById_UpdateEventparameters
{
    public long Id { get; set; }
    public ActiveType RexConnection { get; set; }
    public long RexDuringScheduleId { get; set; }
    public long? RexExceptScheduleId { get; set; }
    public bool IsRexNotUnlockDoor { get; set; }
    public long OrganizationId { get; set; }
    public long DoorId { get; set; }
    public RexType RexType { get; set; }
}