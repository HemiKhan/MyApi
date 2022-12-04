using Domain.Dtos.Door;
using Domain.Events.ControllerEvents.DoorEvents;
using Domain.Models.ScheduleModels;

namespace Domain.Models.ControllerModels.DoorModels;

public partial record DoorAdvanceConfiguration : Entity<long>, IMustHaveOrganization
{

    private DoorAdvanceConfiguration() { }

    private DoorAdvanceConfiguration(AddDoorAdvanceConfgDTO dto)
    {
        var e = new DoorAdvanceConfiguration_Added
            (
             new AddDoorAdvanceConfgDTO
             (
               dto.DuringScheduleId,
               dto.UnlockScheduleId,
               dto.IsDoorMonitor,
               dto.DoorMonitorValues,
               dto.IsLockMonitor,
               dto.LockMonitorValues,
               dto.EnableSupervisedInputs,
               dto.AccessTime,
               dto.LongAccessTime,
               dto.LockWhenLocked,
               dto.LockWhenUnlocked,
               dto.RelayStateLocked,
               dto.BoltInTime,
               dto.BoltOutTime,
               dto.IsAntiPassback,
               dto.AntiPassbackValues
            ));
        RegisterEvent(e);
    }

    public long DoorId { get; private set; }
    public Door Door { get; private set; } = default!;

    public long OrganizationId { get; set; }


    public long? DuringScheduleId { get; private set; } = default!;
    public long? UnlockScheduleId { get; private set; } = default!;

    public Schedule Schedule { get; private set; } = default!;
    public Schedule UnlockSchedule { get; private set; } = default!;

    public bool IsDoorMonitor { get; private set; } = default!;
    public bool IsLockMonitor { get; private set; } = default!;

    //31536000 Max Value
    public int AccessTime { get; private set; } = default!;
    public int LongAccessTime { get; private set; } = default!;
    public string LockWhenLocked { get; private set; } = default!;
    public string LockWhenUnlocked { get; private set; } = default!;
    public RelayStateLockedType RelayStateLocked { get; private set; } = default!;
    public int BoltInTime { get; private set; } = default!;
    public int BoltOutTime { get; private set; } = default!;
    public bool IsAntiPassback { get; private set; } = default!;
    public AntipassbackModeType? AntipassbackMode { get; private set; } = default!;
    public AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode { get; private set; } = default!;

    public int? AntiPassbackTimeout { get; private set; } = default!;

    public LockMonitor? LockMonitor { get; private set; }
    public LockMonitorType? LockType { get; private set; }

    public DoorMonitor? DoorMonitor { get; private set; }
    public bool? CancelAccessTimeOnceDoorIsOpened { get; private set; }
    public bool? EnableSupervisedInputs { get; private set; }
    public int? OpenTooLongTime { get; private set; } = default!;
    public int? PreAlarmTime { get; private set; } = default!;
    public int? RelockTime { get; private set; }



}
