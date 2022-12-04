namespace Domain.Models.ControllerModels.DoorModels;

using Domain.Events.ControllerEvents.DoorEvents;

public partial record DoorAdvanceConfiguration
{
    protected override void When(IDomainEvent @event)
    {
        switch (@event)
        {
            case
                DoorAdvanceConfiguration_Added e:
                Apply(e);
                break;
            case
                LockMonitorANDlockType_Added e:
                Apply(e);
                break;
            case
                DoorAdvanceConfiguration_Updated e:
                Apply(e);
                break;
            default:
                throw QExceptions.EventsExceptions.EventCantBeAddedInWhenMethod;
        }
    }

    public void Apply(DoorAdvanceConfiguration_Added e)
    {
        DuringScheduleId = e.Values.DuringScheduleId;
        UnlockScheduleId = e.Values.UnlockScheduleId;
        IsDoorMonitor = e.Values.IsDoorMonitor;
        DoorMonitor = e.Values!.DoorMonitorValues?.DoorMonitor;
        OpenTooLongTime = e.Values!.DoorMonitorValues?.OpenTooLongTime;
        PreAlarmTime = e.Values!.DoorMonitorValues?.PreAlarmTime;
        CancelAccessTimeOnceDoorIsOpened = e.Values!.DoorMonitorValues?.CancelAccessTimeOnceDoorIsOpened;
        RelockTime = e.Values!.DoorMonitorValues?.RelockTime;
        AccessTime = e.Values.AccessTime;
        LongAccessTime = e.Values.LongAccessTime;
        LockWhenLocked = e.Values.LockWhenLocked;
        LockWhenUnlocked = e.Values.LockWhenUnlocked;
        RelayStateLocked = e.Values.RelayStateLocked;
        EnableSupervisedInputs = e.Values.EnableSupervisedInputs;
        BoltInTime = e.Values.BoltInTime;
        BoltOutTime = e.Values.BoltOutTime;
        IsAntiPassback = e.Values.IsAntiPassback;
        AntipassbackMode = e.Values!.AntiPassbackValues?.AntipassbackMode;
        AntiPassbackTimeout = e.Values!.AntiPassbackValues?.AntiPassbackTimeout;
        AntiPassbackEnforcementMode = e.Values!.AntiPassbackValues?.AntiPassbackEnforcementMode;
    }

    public void Apply(LockMonitorANDlockType_Added e)
    {
        LockMonitor = e.LockMonitor;
        LockType = e.LockType;
    }

    public void Apply(DoorAdvanceConfiguration_Updated e)
    {
        if (e.New.DuringScheduleId != default && e.New.DuringScheduleId != DuringScheduleId)
            DuringScheduleId = e.New.DuringScheduleId;

        if (e.New.UnlockScheduleId != default && e.New.UnlockScheduleId != UnlockScheduleId)
            UnlockScheduleId = e.New.UnlockScheduleId;

        if (e.New.IsDoorMonitor != default && e.New.IsDoorMonitor != IsDoorMonitor)
            IsDoorMonitor = e.New.IsDoorMonitor;

        if (e.New.AccessTime != default && e.New.AccessTime != AccessTime)
            AccessTime = e.New.AccessTime;

        if (e.New.LongAccessTime != default && e.New.LongAccessTime != LongAccessTime)
            LongAccessTime = e.New.LongAccessTime;

        if (e.New.LockWhenLocked != default && e.New.LockWhenLocked != LockWhenLocked)
            LockWhenLocked = e.New.LockWhenLocked;

        if (e.New.LockWhenUnlocked != default && e.New.LockWhenUnlocked != LockWhenUnlocked)
            LockWhenUnlocked = e.New.LockWhenUnlocked;

        if (e.New.RelayStateLocked != default && e.New.RelayStateLocked != RelayStateLocked)
            RelayStateLocked = e.New.RelayStateLocked;

        if (e.New.EnableSupervisedInputs != default && e.New.EnableSupervisedInputs != EnableSupervisedInputs)
            EnableSupervisedInputs = e.New.EnableSupervisedInputs;

        if (e.New.BoltInTime != default && e.New.BoltInTime != BoltInTime)
            BoltInTime = e.New.BoltInTime;

        if (e.New.BoltOutTime != default && e.New.BoltOutTime != BoltOutTime)
            BoltOutTime = e.New.BoltOutTime;

        if (e.New.IsAntiPassback != default && e.New.IsAntiPassback != IsAntiPassback)
            IsAntiPassback = e.New.IsAntiPassback;

        if (e.New.AntipassbackMode != default && e.New.AntipassbackMode != AntipassbackMode)
            AntipassbackMode = e.New.AntipassbackMode;

        if (e.New.AntiPassbackTimeout != default && e.New.AntiPassbackTimeout != AntiPassbackTimeout)
            AntiPassbackTimeout = e.New.AntiPassbackTimeout;

        if (e.New.AntiPassbackEnforcementMode != default && e.New.AntiPassbackEnforcementMode != AntiPassbackEnforcementMode)
            AntiPassbackEnforcementMode = e.New.AntiPassbackEnforcementMode;
    }
}
