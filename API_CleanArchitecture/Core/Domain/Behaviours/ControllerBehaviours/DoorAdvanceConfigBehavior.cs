namespace Domain.Models.ControllerModels.DoorModels;

using Domain.Dtos.Door;
using Domain.Events.ControllerEvents.DoorEvents;
using System.Collections.Generic;
using System.Linq;

public partial record DoorAdvanceConfiguration
{
    //Behavior
    public static DoorAdvanceConfiguration Create(AddDoorAdvanceConfgDTO dto) => 
        new(dto);

    public void AddIfIsLockMonitorEnabled(LockMonitor? lockMonitor, LockMonitorType? lockType)
    {
        if (IsLockMonitor)
        {
            var props = new List<string>();
            if (!lockMonitor.HasValue)
                props.Add("Lock Monitor");
            if (!lockType.HasValue)
                props.Add("Lock Type");
            if (props.Any())
                throw new QException(ValidationExceptions.GetValidationErrors("Must not be null when Lock Monitor is Enabled.", props.ToArray()));
            var e = new LockMonitorANDlockType_Added(lockMonitor, lockType);
            //Apply(e);
            RegisterEvent(e);
        }
    }

    public void AddIfIsDoorMonitorEnabled(DoorMonitor? doorMonitor, bool? cancelAccessTimeOnceDoorIsOpened, bool? enableSupervisedInputs, int? openTooLongTime, int? preAlarmTime, int? relockTime = 0)
    {
        if (IsDoorMonitor)
        {
            var props = new List<string>();
            if (!doorMonitor.HasValue)
                props.Add("Door Monitor");
            if (!cancelAccessTimeOnceDoorIsOpened.HasValue)
                props.Add("CancelAccessTimeOnceDoorIsOpened");

            if (!openTooLongTime.HasValue)
                props.Add("OpenTooLongTime");
            if (!preAlarmTime.HasValue)
                props.Add("PreAlarmTime");

            var validationErrors = ValidationExceptions.GetValidationErrors("Must not be null when Lock Monitor is Enabled.", props.ToArray());
            if (CancelAccessTimeOnceDoorIsOpened.HasValue && CancelAccessTimeOnceDoorIsOpened.Value)
                validationErrors.Add(new("RelockTime", "RelockTime Must not be null when CancelAccessTimeOnceDoorIsOpened is Enabled"));


            if (validationErrors.Any())
                throw new QException(validationErrors);


            DoorMonitor = doorMonitor;
            CancelAccessTimeOnceDoorIsOpened = cancelAccessTimeOnceDoorIsOpened;
            if (CancelAccessTimeOnceDoorIsOpened.HasValue && CancelAccessTimeOnceDoorIsOpened.Value)
                RelockTime = relockTime;


            OpenTooLongTime = openTooLongTime;
            PreAlarmTime = preAlarmTime;

        }
    }

    public bool Update(DoorAdvanceConfig_GetById_DTO dto)
    {
        DoorAdvanceConfig_GetById_UpdateEventParameterDTO oldValue = new DoorAdvanceConfig_GetById_UpdateEventParameterDTO();
        DoorAdvanceConfig_GetById_UpdateEventParameterDTO newValue = new DoorAdvanceConfig_GetById_UpdateEventParameterDTO();

        bool detectChanges = false;
        if (!DuringScheduleId.Equals(dto.DuringScheduleId))
        {
            oldValue.DuringScheduleId = DuringScheduleId;
            newValue.DuringScheduleId = dto.DuringScheduleId;
            detectChanges = true;
        }

        if (!UnlockScheduleId.Equals(dto.UnlockScheduleId))
        {
            oldValue.UnlockScheduleId = UnlockScheduleId;
            newValue.UnlockScheduleId = dto.UnlockScheduleId;
            detectChanges = true;
        }

        if (!LockMonitor.Equals(dto.LockMonitor))
        {
            oldValue.LockMonitor = LockMonitor;
            newValue.LockMonitor = dto.LockMonitor;
            detectChanges = true;
        }

        if (!LockType.Equals(dto.LockType))
        {
            oldValue.LockType = LockType;
            newValue.LockType = dto.LockType;
            detectChanges = true;
        }

        if (!DoorMonitor.Equals(dto.DoorMonitor))
        {
            oldValue.DoorMonitor = DoorMonitor;
            newValue.DoorMonitor = dto.DoorMonitor;
            detectChanges = true;
        }

        if (!EnableSupervisedInputs.Equals(dto.EnableSupervisedInputs))
        {
            oldValue.EnableSupervisedInputs = EnableSupervisedInputs;
            newValue.EnableSupervisedInputs = dto.EnableSupervisedInputs;
            detectChanges = true;
        }

        if (!PreAlarmTime.Equals(dto.PreAlarmTime))
        {
            oldValue.PreAlarmTime = PreAlarmTime;
            newValue.PreAlarmTime = dto.PreAlarmTime;
            detectChanges = true;
        }

        if (!OpenTooLongTime.Equals(dto.OpenTooLongTime))
        {
            oldValue.OpenTooLongTime = OpenTooLongTime;
            newValue.OpenTooLongTime = dto.OpenTooLongTime;
            detectChanges = true;
        }

        if (!CancelAccessTimeOnceDoorIsOpened.Equals(dto.CancelAccessTimeOnceDoorIsOpened))
        {
            oldValue.CancelAccessTimeOnceDoorIsOpened = CancelAccessTimeOnceDoorIsOpened;
            newValue.CancelAccessTimeOnceDoorIsOpened = dto.CancelAccessTimeOnceDoorIsOpened;
            detectChanges = true;
        }

        if (!RelockTime.Equals(dto.RelockTime))
        {
            oldValue.RelockTime = RelockTime;
            newValue.RelockTime = dto.RelockTime;
            detectChanges = true;
        }

        if (!AccessTime.Equals(dto.AccessTime))
        {
            oldValue.AccessTime = AccessTime;
            newValue.AccessTime = dto.AccessTime;
            detectChanges = true;
        }

        if (!LongAccessTime.Equals(dto.LongAccessTime))
        {
            oldValue.LongAccessTime = LongAccessTime;
            newValue.LongAccessTime = dto.LongAccessTime;
            detectChanges = true;
        }

        if (!LockWhenLocked.Equals(dto.LockWhenLocked))
        {
            oldValue.LockWhenLocked = LockWhenLocked;
            newValue.LockWhenLocked = dto.LockWhenLocked;
            detectChanges = true;
        }

        if (!LockWhenUnlocked.Equals(dto.LockWhenUnlocked))
        {
            oldValue.LockWhenUnlocked = LockWhenUnlocked;
            newValue.LockWhenUnlocked = dto.LockWhenUnlocked;
            detectChanges = true;
        }

        if (!RelayStateLocked.Equals(dto.RelayStateLocked))
        {
            oldValue.RelayStateLocked = RelayStateLocked;
            newValue.RelayStateLocked = dto.RelayStateLocked;
            detectChanges = true;
        }

        if (!BoltInTime.Equals(dto.BoltInTime))
        {
            oldValue.BoltInTime = BoltInTime;
            newValue.BoltInTime = dto.BoltInTime;
            detectChanges = true;
        }

        if (!BoltOutTime.Equals(dto.BoltOutTime))
        {
            oldValue.BoltOutTime = BoltOutTime;
            newValue.BoltOutTime = dto.BoltOutTime;
            detectChanges = true;

        }

        if (!IsAntiPassback.Equals(dto.IsAntiPassback))
        {
            oldValue.IsAntiPassback = IsAntiPassback;
            newValue.IsAntiPassback = dto.IsAntiPassback;
            detectChanges = true;
        }

        if (!AntipassbackMode.Equals(dto.AntipassbackMode))
        {
            oldValue.AntipassbackMode = AntipassbackMode;
            newValue.AntipassbackMode = dto.AntipassbackMode;
            detectChanges = true;
        }

        if (!AntiPassbackTimeout.Equals(dto.AntiPassbackTimeout))
        {
            oldValue.AntiPassbackTimeout = AntiPassbackTimeout;
            newValue.AntiPassbackTimeout = dto.AntiPassbackTimeout;
            detectChanges = true;
        }

        if (!AntiPassbackEnforcementMode.Equals(dto.AntiPassbackEnforcementMode))
        {
            oldValue.AntiPassbackEnforcementMode = AntiPassbackEnforcementMode;
            newValue.AntiPassbackEnforcementMode = dto.AntiPassbackEnforcementMode;
            detectChanges = true;
        }

        if (!IsDoorMonitor.Equals(dto.IsDoorMonitor))
        {
            oldValue.IsDoorMonitor = IsDoorMonitor;
            newValue.IsDoorMonitor = dto.IsDoorMonitor;
            detectChanges = true;
        }
        if (detectChanges == true)
        {
            var e = new DoorAdvanceConfiguration_Updated(dto.Id, oldValue, newValue);
            When(e);
            RegisterEvent(e);

        }
        return detectChanges;
    }
}
