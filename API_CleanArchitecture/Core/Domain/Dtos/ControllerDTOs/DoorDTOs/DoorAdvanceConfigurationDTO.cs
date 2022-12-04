namespace Domain.Dtos.Door
{
    public record DoorMonitorValues(
        DoorMonitor DoorMonitor,
        int PreAlarmTime,
        int OpenTooLongTime,
        bool CancelAccessTimeOnceDoorIsOpened,
        int? RelockTime
    );

    public record LockMonitorValues(
        LockMonitor? LockMonitor,
        LockMonitorType? LockType
    );

    public record AntiPassbackValues(
        AntipassbackModeType? AntipassbackMode,
        AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode,
        int? AntiPassbackTimeout
    );

    public record AddDoorAdvanceConfgDTO(
        long? DuringScheduleId,
        long? UnlockScheduleId,
        bool IsDoorMonitor,
        DoorMonitorValues? DoorMonitorValues,
        bool IsLockMonitor,
        LockMonitorValues? LockMonitorValues,
        bool EnableSupervisedInputs,
        int AccessTime,
        int LongAccessTime,
        string LockWhenLocked,
        string LockWhenUnlocked,
        RelayStateLockedType RelayStateLocked,
        int BoltInTime,
        int BoltOutTime,
        bool IsAntiPassback,
        AntiPassbackValues? AntiPassbackValues
    ){}

    public record UpdateDoorAdvanceConfgDTO(
        long? Id,
        long? DuringScheduleId,
        long? UnlockScheduleId,
        LockMonitor? LockMonitor,
        LockMonitorType? LockType,
        DoorMonitor? DoorMonitor,
        bool? EnableSupervisedInputs,
        int? PreAlarmTime,
        int? OpenTooLongTime,
        bool? CancelAccessTimeOnceDoorIsOpened,
        int? RelockTime,
        int AccessTime,
        int LongAccessTime,
        string LockWhenLocked,
        string LockWhenUnlocked,
        RelayStateLockedType RelayStateLocked,
        int BoltInTime,
        int BoltOutTime,
        bool IsAntiPassback,
        AntipassbackModeType? AntipassbackMode,
        bool IsDoorMonitor,
        int? AntiPassbackTimeout,
        AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode
    );

    public record DoorAdvanceConfig_GetById_DTO(
        long? Id,
        long? DuringScheduleId,
        long? UnlockScheduleId,
        LockMonitor? LockMonitor,
        LockMonitorType? LockType,
        DoorMonitor? DoorMonitor,
        bool? EnableSupervisedInputs,
        int? PreAlarmTime,
        int? OpenTooLongTime,
        bool? CancelAccessTimeOnceDoorIsOpened,
        int? RelockTime,
        int AccessTime,
        int LongAccessTime,
        string LockWhenLocked,
        string LockWhenUnlocked,
        RelayStateLockedType RelayStateLocked,
        int BoltInTime,
        int BoltOutTime,
        bool IsAntiPassback,
        AntipassbackModeType? AntipassbackMode,
        bool IsDoorMonitor,
        int? AntiPassbackTimeout,
        AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode
    ){}

    public record GetAllDoorAdvanceConfgDTO(
        long Id,
        long DuringScheduleId,
        long UnlockScheduleId,
        bool IsDoorMonitor,
        DoorMonitor DoorMonitor,
        bool CancelAccessTimeOnceDoorIsOpened,
        bool EnableSupervisedInputs,
        short AccessTime,
        short LongAccessTime,
        short OpenTooLongTime,
        short PreAlarmTime,
        string LockWhenLocked,
        string LockWhenUnlocked,
        RelayStateLockedType RelayStateLocked,
        short BoltInTime,
        short BoltOutTime,
        bool IsAntiPassback,
        AntipassbackModeType? AntipassbackMode,
        AntiPassbackEnforcementModeType? AntiPassbackEnforcementMode
    );

    public record DeleteDoorAdvanceConfgDTO(long Id);
}
