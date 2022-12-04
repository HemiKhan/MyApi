namespace Domain.Events.ControllerEvents.DoorEvents;

using Domain.Constants;
using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.ReaderDTOs;
using Domain.Models.ControllerModels.DoorModels;
using Domain.Models.ControllerModels.DoorModels.ReaderModeds;
using Domain.Models.ControllerModels.DoorModels.RexModels;

public record Door_Added(
    long ControllerId,
    Door_Add_DTO AddDoorCommandValues) : IDomainEvent;


public record Door_Created(string Name, string Lock, DoorType DoorType, Models.ControllerModels.Controller Controller) : IDomainEvent;
public record DoorAdvanceConfiguration_Added(AddDoorAdvanceConfgDTO Values) : IDomainEvent;
public record DoorAdvanceConfiguration_Updated(long? Id, DoorAdvanceConfig_GetById_UpdateEventParameterDTO Old, DoorAdvanceConfig_GetById_UpdateEventParameterDTO New) : IDomainEvent;
public record LockMonitorANDlockType_Added(LockMonitor? LockMonitor, LockMonitorType? LockType) : IDomainEvent;
public record DoorReader_Added(AddReaderDTO Values, Models.ControllerModels.DoorModels.Door Door) : IDomainEvent;

public record DoorRex_Added(Rex_Add_DTO Values, Models.ControllerModels.DoorModels.Door Door) : IDomainEvent;



public record Door_NameUpdated(long Id, string Old, string New) : IDomainEvent;
public record Door_Updated(long Id, Door_UpdateEventParameters Old, Door_UpdateEventParameters New) : IDomainEvent;

public record DoorState_Changed(DoorState State) : IDomainEvent;
public record DoorType_Changed(DoorType DoorType) : IDomainEvent;
public record Door_Deleted(Door DoorType) : IDeleteDomainEvent;

public record ReaderIdenticationType_Deleted(ReaderIdentificationType ReaderIdentificationType) : IDeleteDomainEvent;
public record Rex_Deleted(Rex Rex) : IDeleteDomainEvent;




#region Door update event Parameters Classes

public class Door_UpdateEventParameters
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Lock { get; set; }

    public DoorType DoorType { get; set; }
    public DoorAdvanceConfig_GetById_UpdateEventParameterDTO DoorAdvanceConfig { get; set; }
    public IEnumerable<Reader_GetById_UpdateEventparametersDTO> Readers { get; set; }
    public IEnumerable<Rex_GetById_UpdateEventparameters> Rexes { get; set; }
}
public class DoorAdvanceConfig_GetById_UpdateEventParameterDTO
{
    public long? DuringScheduleId { get; set; }
    public long? UnlockScheduleId { get; set; }

    public LockMonitor? LockMonitor { get; set; }
    public LockMonitorType? LockType { get; set; }

    public DoorMonitor? DoorMonitor { get; set; }
    public bool? EnableSupervisedInputs { get; set; }
    public int? PreAlarmTime { get; set; }
    public int? OpenTooLongTime { get; set; }
    public bool? CancelAccessTimeOnceDoorIsOpened { get; set; }
    public int? RelockTime { get; set; }

    public int AccessTime { get; set; }
    public int LongAccessTime { get; set; }
    public string LockWhenLocked { get; set; }
    public string LockWhenUnlocked { get; set; }
    public RelayStateLockedType RelayStateLocked { get; set; }
    public int BoltInTime { get; set; }
    public int BoltOutTime { get; set; }
    public bool IsDoorMonitor { get; set; }

    public bool IsAntiPassback { get; set; }
    public AntipassbackModeType? AntipassbackMode { get; set; }
    public int? AntiPassbackTimeout { get; set; }
    public AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode { get; set; }
}

public class Reader_GetById_UpdateEventparametersDTO
{
    public long Id { get; set; }
    public ReaderType ReaderType { get; set; }

    public ReaderProtocol Protocol { get; set; }
    public LEDType? LEDType { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public long? AreaInId { get; set; }
    public long? AreaOutId { get; set; }
    public string Location { get; set; }
    public int HeartbeatInterval { get; set; }
    public int Timeout { get; set; }
    public string LPNCameraSN { get; set; }
    public bool IsTimeAttendance { get; set; }
    public bool IsEnrollmentReader { get; set; }
    public ActiveType LEDActiveLevel { get; set; }
    public ActiveType TamperingType { get; set; }
    public ActiveType BeeperType { get; set; }
    public List<ReaderIdentificationType_GetById_UpdateEventDTO> ReaderIdentificationType { get; } = new();
}

public record ReaderIdentificationType_GetById_UpdateEventDTO : ReaderIdentificationTypeDTO
{
    public long Id { get; set; }
}



#endregion