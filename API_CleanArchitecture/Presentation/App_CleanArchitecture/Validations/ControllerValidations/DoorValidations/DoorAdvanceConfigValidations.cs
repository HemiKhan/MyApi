using Domain.Constants;
using Domain.Dtos.Door;

using FluentValidation;

namespace App_CleanArchitecture.Validations.Door
{
    public class AddDoorAdvanceConfigDTOValidator : AbstractValidator<AddDoorAdvanceConfgDTO>
    {
        public AddDoorAdvanceConfigDTOValidator()
        {
            RuleFor(x => x.AccessTime).GreaterThan(0);
            RuleFor(x => x.LongAccessTime).GreaterThan(0);

            RuleFor(x => x.BoltInTime).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BoltOutTime).GreaterThanOrEqualTo(0);

            RuleFor(x => x.DuringScheduleId).NotEqual(0);
            RuleFor(x => x.UnlockScheduleId).NotEqual(0);

            RuleFor(x => x.LockWhenLocked).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.LockWhenUnlocked).MaximumLength(3).NotNull().NotEmpty();

            RuleFor(o => o.RelayStateLocked).Must(x => Enum.IsDefined(typeof(RelayStateLockedType), x));
        }
    }

    public class UpdateDoorAdvanceConfigDTOValidator : AbstractValidator<DoorAdvanceConfig_GetById_DTO>
    {
        public UpdateDoorAdvanceConfigDTOValidator()
        {
            //RuleFor(x => x.AccessTime).GreaterThan(0);
            //RuleFor(x => x.LongAccessTime).GreaterThan(0);

            //RuleFor(x => x.BoltInTime).GreaterThanOrEqualTo(0);
            //RuleFor(x => x.BoltOutTime).GreaterThanOrEqualTo(0);

            RuleFor(x => x.Id).NotEqual(0);

            RuleFor(x => x.DuringScheduleId).NotEqual(0);
            RuleFor(x => x.UnlockScheduleId).NotEqual(0);

            RuleFor(x => x.LockWhenLocked).MaximumLength(3).NotNull().NotEmpty();
            RuleFor(x => x.LockWhenUnlocked).MaximumLength(3).NotNull().NotEmpty();

            RuleFor(o => o.RelayStateLocked).Must(x => Enum.IsDefined(typeof(RelayStateLockedType), x));
        }
    }

    public class DeleteDoorAdvanceConfigDTOValidator : AbstractValidator<DeleteDoorAdvanceConfgDTO>
    {
        public DeleteDoorAdvanceConfigDTOValidator()
        {
            RuleFor(_ => _.Id).NotNull().GreaterThan(0);
        }
    }
}
