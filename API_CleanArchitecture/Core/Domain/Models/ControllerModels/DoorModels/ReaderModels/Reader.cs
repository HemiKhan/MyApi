using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
using Domain.Events.ControllerEvents.DoorEvents.ReaderEvents;
using Domain.Models.ControllerModels.DoorModels.ReaderModeds;


namespace Domain.Models.ControllerModels.DoorModels.ReaderModels;

public partial record Reader : Entity<long>, IMustHaveToken, IMustHaveOrganization
{
    Reader() { }
    Reader(long controllerId, long doorId, string name, string description, ReaderProtocol protocol, LEDType? lEDType, long? areaIn, long? areaOut, string location, int heartbeatInterval, int timeout, string lPNCameraSN, bool isTimeAttendance, bool isEnrollmentReader, ActiveType lEDActiveLevel, ActiveType tamperingType, ActiveType beeperType, ReaderType readerType, AddReaderIdentificationTypeDTO[] readerIdentificationType)
    {
        var e = new Reader_Created(
                                   controllerId,
                                   doorId,
                                   lEDType,
                                   protocol,
                                   name,
                                   description,
                                   areaIn,
                                   areaOut,
                                   location,
                                   heartbeatInterval,
                                   timeout,
                                   lPNCameraSN,
                                   isTimeAttendance,
                                   isEnrollmentReader,
                                   lEDActiveLevel,
                                   tamperingType,
                                   beeperType,
                                   readerType,
                                   readerIdentificationType);


        RegisterEvent(e);
    }

    public string Token { get; set; } = string.Empty!;
    public long OrganizationId { get; set; }

    public Door Door { get; private set; } = default!;
    public long DoorId { get; private set; } = default!;

    public long ControllerId { get; private set; }


    public ReaderType ReaderType { get; private set; }
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public ReaderProtocol Protocol { get; private set; } = default!;
    public LEDType? LEDType { get; private set; }

    public long? AreaInId { get; private set; } = default!;
    public Area? AreaIn { get; private set; } = default!;

    public long? AreaOutId { get; private set; } = default!;
    public Area? AreaOut { get; private set; } = default!;

    public string Location { get; private set; } = default!;
    public int HeartbeatInterval { get; private set; } = default!;
    public int Timeout { get; private set; } = default!;
    public string? LPNCameraSN { get; private set; } = default!;
    public bool IsTimeAttendance { get; private set; } = default!;
    public bool IsEnrollmentReader { get; private set; } = default!;
    public ActiveType LEDActiveLevel { get; private set; } = default!;
    public ActiveType TamperingType { get; private set; } = default!;
    public ActiveType BeeperType { get; private set; } = default!;
    public List<ReaderIdentificationType> ReaderIdentificationType { get; private set; } = new()!;

}