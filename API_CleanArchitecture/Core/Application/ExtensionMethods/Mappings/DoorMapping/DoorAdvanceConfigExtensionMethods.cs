using Domain.Dtos.Door;
using Domain.Models.ControllerModels.DoorModels;

namespace Application.ExtensionMethods.Mappings.DoorMapping
{
    internal static class DoorAdvanceConfigExtensionMethods
    {
 //       public static DoorAdvanceConfiguration AsDomainModel(this AddDoorAdvanceConfgDTO dto)
 //       {
 //           var dac = new DoorAdvanceConfiguration
 //    (dto.IsDoorMonitor,
 //    dto.IsLockMonitor,
 //    dto.AccessTime,
 //    dto.LongAccessTime,
 //    dto.LockWhenLocked,
 //    dto.LockWhenUnlocked,
 //    dto.RelayStateLocked,
 //    dto.BoltInTime,
 //    dto.BoltOutTime,
 //dto.IsAntiPassback,
 //dto.AntipassbackMode,
 //dto.AntiPassbackTimeout,
 //dto.AntiPassbackEnforcementMode);


 //           dac.AddIfIsLockMonitorEnabled(dto.LockMonitorValues?.LockMonitor, dto.LockMonitorValues?.LockType);
 //           dac.AddIfIsDoorMonitorEnabled(dto.DoorMonitorValues?.DoorMonitor, dto.DoorMonitorValues?.CancelAccessTimeOnceDoorIsOpened, dto.DoorMonitorValues?.EnableSupervisedInputs, dto.DoorMonitorValues?.OpenTooLongTime, dto.DoorMonitorValues?.PreAlarmTime, dto.DoorMonitorValues?.RelockTime);

 //           return dac;
 //       }

        public static DoorAdvanceConfiguration AsDomainModel(this UpdateDoorAdvanceConfgDTO dto)
        {
            return default!;
            //return new DoorAdvanceConfiguration
            //    (

            //    dto.DuringScheduleId,
            //    dto.UnlockScheduleId,

            //    dto.AccessTime,
            //    dto.LongAccessTime,
            //    dto.OpenTooLongTime,
            //    dto.PreAlarmTime,
            //    dto.LockWhenLocked,
            //    dto.LockWhenUnlocked,
            //    dto.RelayStateLocked,
            //    dto.BoltInTime,
            //    dto.BoltOutTime,
            //dto.IsAntiPassback,
            //dto.AntipassbackMode,
            //dto.AntiPassbackTimeout,
            //dto.AntiPassbackEnforcementMode
            //    )
            //{ Id = dto.Id };
        }


        public static DoorAdvanceConfiguration AsDomainModel(this DeleteDoorAdvanceConfgDTO dto)
        {
            return default!;
            //return new DoorAdvanceConfiguration
            //    (
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!,
            //    default!
            //    )
            //{ Id = dto.Id };
        }
    }
}
