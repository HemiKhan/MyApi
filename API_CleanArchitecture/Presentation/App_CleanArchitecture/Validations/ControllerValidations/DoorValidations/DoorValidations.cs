using App_CleanArchitecture.Constants;
using App_CleanArchitecture.Validations.ControllerValidations.DoorValidations.RexValidations;
using App_CleanArchitecture.Validations.Reader;
using Domain.Constants;
using Domain.Dtos;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;
using Domain.Dtos.Door;
using Domain.Dtos.ReaderDTOs;
using SharedKernel;
using FluentValidation;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App_CleanArchitecture.Validations.Door
{
    public class AddDoorDTOValidator : AbstractValidator<Door_Add_DTO>
    {
        public AddDoorDTOValidator()
        {
            RuleFor(o => o.ControllerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(o => o.Name).MaximumLength(64).NotNull().NotEmpty();
            RuleFor(o => o.Lock).NotNull().NotEmpty();
            RuleFor(o => o.DoorType).Must(x => Enum.IsDefined(typeof(DoorType), x));

            RuleFor(x => x.DoorAdvanceConfig).SetValidator(new AddDoorAdvanceConfigDTOValidator());

            Door1Config();
            Door2Config();

            WhenAntipassbackIsTrue();
            WhenAntipassbaclIsFalse();
        }

        private void Door1Config() => When(type => type.DoorType is DoorType.Door, () =>
        {
            RuleFor(x => x.Readers.Count()).LessThanOrEqualTo(2).WithMessage(ValidationMessages.DoorTypeDoorReadersMustBeLessThanOrEqualTo2);
            When(o => o.Readers is not null && o.Readers.Any(), () =>
            {
                RuleForEach(x => x.Readers).SetValidator(new AddReaderDTOValidator());

                RuleFor(x => x.Readers)
                .Must((x, type) => IsDuplicated(x.Readers, _ => _.ReaderType == ReaderType.Reader1) && IsDuplicated(x.Readers, _ => _.ReaderType == ReaderType.Reader2))
                .WithMessage("Reader Type Cannot be Same");
            });

            RuleFor(x => x.Rexes!.Count()).LessThanOrEqualTo(2).WithMessage(ValidationMessages.DoorTypeDoorRexMustBeLessThanOrEqualTo2);
            When(o => o.Rexes is not null && o.Rexes.Any(), () =>
            {
                RuleForEach(x => x.Rexes).SetValidator(new AddRexDTOValidator());

                RuleFor(x => x.Rexes)
                .Must((x, type) => IsDuplicated(x.Rexes, _ => _.RexType == RexType.Rex1) && IsDuplicated(x.Rexes, _ => _.RexType == RexType.Rex2))
                .WithMessage("Rex Type Cannot be Same");
            });

            RuleFor(o => o.Lock).Matches(@"^([\w]+:[\w]+)");
            RuleFor(x => x).Must(x => x.Lock == "12V:Relay" || x.Lock == "12V:None" || x.Lock == "Relay:12V" || x.Lock == "Relay:None").WithMessage("Lock Must Be '12V:Relay' or '12V:None' or 'Relay:12V' or 'Relay:None'");

            WhenLockMonitorIsFalse();
            WhenLockMonitorIsTrueInDoor1Config();
        });

        private void Door2Config()
        {
            When(type => type.DoorType is DoorType.Door1, () =>
            {
                RuleFor(x => x).Must(x => x.Lock == "12V" || x.Lock == "Relay").WithMessage("Lock Must Be '12V' or 'Relay'");
                Door2ConfigReaderAndRexValidations(DoorType.Door1);
                RuleFor(o => o.DoorAdvanceConfig.IsLockMonitor).Equal(false);
                WhenLockMonitorIsFalse();
            });
            When(type => type.DoorType is DoorType.Door2, () =>
            {
                RuleFor(x => x).Must(x => x.Lock == "12V" || x.Lock == "Relay" || x.Lock == "None").WithMessage("Lock Must Be '12V' or 'Relay' or 'None'");
                Door2ConfigReaderAndRexValidations(DoorType.Door2);
                RuleFor(o => o.DoorAdvanceConfig.IsLockMonitor).Equal(false);
                WhenLockMonitorIsFalse();
            });
        }

        private void Door2ConfigReaderAndRexValidations(DoorType doorType)
        {
            When(o => o.Readers is null, () =>
            {
                RuleFor(r => r.Readers!).Null();
            });

            When(o => o.Rexes is null, () =>
            {
                RuleFor(r => r.Rexes!).Null();
            });

            When(o => o.Readers is not null && o.Readers.Any(), () =>
            {
                RuleForEach(x => x.Readers).SetValidator(new AddReaderDTOValidator());

                RuleFor(x => x.Readers.Count()).LessThanOrEqualTo(1).WithMessage(ValidationMessages.DoorTypeDoor1ReadersMustBeLessThanOrEqualTo1);
                if (doorType is DoorType.Door1)
                    RuleFor(o => o.Readers.First().ReaderType).Equal(ReaderType.Reader1);
                else if (doorType is DoorType.Door2)
                    RuleFor(o => o.Readers.First().ReaderType).Equal(ReaderType.Reader2);
            });

            When(o => o.Rexes is not null && o.Rexes.Any(), () =>
            {
                RuleForEach(x => x.Rexes).SetValidator(new AddRexDTOValidator());

                RuleFor(x => x.Rexes!.Count()).LessThanOrEqualTo(1).WithMessage(ValidationMessages.DoorTypeDoor1ReadersMustBeLessThanOrEqualTo1);
                if (doorType is DoorType.Door1)
                    RuleFor(o => o.Rexes!.First().RexType).Equal(RexType.Rex1);
                else if (doorType is DoorType.Door2)
                    RuleFor(o => o.Rexes!.First().RexType).Equal(RexType.Rex2);
            });
        }

        private void DoorMonitorIsFalse()
        {
            RuleFor<DoorMonitorValues>(x => x.DoorAdvanceConfig.DoorMonitorValues!).Null();
        }

        private void WhenIsDoorMonitorIsTrue()
        {
            RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues).NotNull();
            RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues!.DoorMonitor).Must(x => Enum.IsDefined(typeof(DoorMonitor), x));
            RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues!.OpenTooLongTime).GreaterThan(o => o.DoorAdvanceConfig.DoorMonitorValues!.PreAlarmTime).NotEmpty();
            RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues!.PreAlarmTime).LessThan(o => o.DoorAdvanceConfig.DoorMonitorValues!.OpenTooLongTime).NotEmpty();
            When(_ => _.DoorAdvanceConfig.DoorMonitorValues!.CancelAccessTimeOnceDoorIsOpened, () =>
            {
                RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues!.RelockTime).NotNull();

            });

            When(_ => _.DoorAdvanceConfig.DoorMonitorValues!.CancelAccessTimeOnceDoorIsOpened is false, () =>
            {
                RuleFor(x => x.DoorAdvanceConfig.DoorMonitorValues!.RelockTime).Null();
            });
        }

        private void WhenAntipassbaclIsFalse()
        {
            When(_ => _.DoorAdvanceConfig.IsAntiPassback is false, () =>
            {
                RuleFor(x => x.DoorAdvanceConfig.AntiPassbackValues!).Null();

                When(o => o.DoorAdvanceConfig.IsDoorMonitor, () =>
                {
                    WhenIsDoorMonitorIsTrue();
                });

                When(o => o.DoorAdvanceConfig.IsDoorMonitor is false, () =>
                {
                    DoorMonitorIsFalse();

                });
            });
        }

        private void WhenAntipassbackIsTrue() => When(_ => _.DoorAdvanceConfig.IsAntiPassback, () =>
        {
            RuleFor(o => o.DoorAdvanceConfig.AntiPassbackValues!.AntipassbackMode).Must(x => Enum.IsDefined(typeof(AntipassbackModeType), x!)).NotNull();
            RuleFor(o => o.DoorAdvanceConfig.AntiPassbackValues!.AntiPassbackEnforcementMode).Must(x => Enum.IsDefined(typeof(AntiPassbackEnforcementModeType), x!)).NotNull();
            When(type => type.DoorAdvanceConfig.AntiPassbackValues!.AntipassbackMode is AntipassbackModeType.Logical, () =>
            {
                RuleFor(o => o.DoorAdvanceConfig.AntiPassbackValues!.AntiPassbackTimeout).Empty();
            });
            When(type => type.DoorAdvanceConfig.AntiPassbackValues!.AntipassbackMode is AntipassbackModeType.TimeLogical, () =>
            {
                RuleFor(o => o.DoorAdvanceConfig.AntiPassbackValues!.AntiPassbackTimeout).GreaterThan(0).NotEmpty();
            });

            RuleFor(o => o.DoorAdvanceConfig.IsDoorMonitor).Equal(true);
            WhenIsDoorMonitorIsTrue();
        });

        private void WhenLockMonitorIsTrueInDoor1Config() =>
                    When(o => o.DoorAdvanceConfig.IsLockMonitor is true, () =>
                    {
                        RuleFor(x => x.DoorAdvanceConfig.LockMonitorValues).NotNull();
                        RuleFor(x => x.DoorAdvanceConfig.LockMonitorValues!.LockMonitor).Must(x => Enum.IsDefined(typeof(LockMonitor), x!));
                        RuleFor(x => x.DoorAdvanceConfig.LockMonitorValues!.LockType).Must(x => Enum.IsDefined(typeof(LockMonitorType), x!));
                    });

        private void WhenLockMonitorIsFalse() =>
                    When(o => o.DoorAdvanceConfig.IsLockMonitor is false, () =>
                    {
                        RuleFor(x => x.DoorAdvanceConfig.LockMonitorValues).Null().Empty();
                    });

        private bool IsDuplicated<T>(IEnumerable<T> listToCheck, Func<T, bool> expression)
        {
            var matchValues = listToCheck.Where(expression);
            if (matchValues.Count() <= 1)
                return true;
            return false;
        }
    }

    public class UpdateDoorDTOValidator : AbstractValidator<Door_GetById_DTO>
    {
        public UpdateDoorDTOValidator()
        {
            RuleFor(o => o.Id).GreaterThan(0).NotEmpty();
            RuleFor(o => o.ControllerId).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(o => o.Name).MaximumLength(64).NotNull().NotEmpty();
            RuleFor(o => o.Lock).NotNull().NotEmpty();
            RuleFor(o => o.DoorType).Must(x => Enum.IsDefined(typeof(DoorType), x));

            RuleFor(x => x.DoorAdvanceConfig).SetValidator(new UpdateDoorAdvanceConfigDTOValidator());

            Door1Config();
            Door2Config();
        }

        private void Door1Config() => When(type => type.DoorType is DoorType.Door, () =>
        {
            RuleFor(x => x.Readers.Count()).LessThanOrEqualTo(2).WithMessage(ValidationMessages.DoorTypeDoorReadersMustBeLessThanOrEqualTo2);
            When(o => o.Readers is not null && o.Readers.Any(), () =>
            {
                RuleForEach(x => x.Readers).SetValidator(new UpdateReaderDTOValidator());

                RuleFor(x => x.Readers)
                .Must((x, type) => IsDuplicated(x.Readers, _ => _.ReaderType == ReaderType.Reader1) && IsDuplicated(x.Readers, _ => _.ReaderType == ReaderType.Reader2))
                .WithMessage("Reader Type Cannot be Same");
            });

            RuleFor(x => x.Rexes!.Count()).LessThanOrEqualTo(2).WithMessage(ValidationMessages.DoorTypeDoorRexMustBeLessThanOrEqualTo2);
            When(o => o.Rexes is not null && o.Rexes.Any(), () =>
            {
                RuleForEach(x => x.Rexes).SetValidator(new UpdateRexDTOValidator());

                RuleFor(x => x.Rexes)
                .Must((x, type) => IsDuplicated(x.Rexes, _ => _.RexType == RexType.Rex1) && IsDuplicated(x.Rexes, _ => _.RexType == RexType.Rex2))
                .WithMessage("Rex Type Cannot be Same");
            });

            RuleFor(o => o.Lock).Matches(@"^([\w]+:[\w]+)");
            RuleFor(x => x).Must(x => x.Lock == "12V:Relay" || x.Lock == "12V:None" || x.Lock == "Relay:12V" || x.Lock == "Relay:None").WithMessage("Lock Must Be '12V:Relay' or '12V:None' or 'Relay:12V' or 'Relay:None'");

        });

        private void Door2Config()
        {
            When(type => type.DoorType is DoorType.Door1, () =>
            {
                RuleFor(x => x).Must(x => x.Lock == "12V" || x.Lock == "Relay").WithMessage("Lock Must Be '12V' or 'Relay'");
                Door2ConfigReaderAndRexValidations(DoorType.Door1);
            });
            When(type => type.DoorType is DoorType.Door2, () =>
            {
                RuleFor(x => x).Must(x => x.Lock == "12V" || x.Lock == "Relay" || x.Lock == "None").WithMessage("Lock Must Be '12V' or 'Relay' or 'None'");
                Door2ConfigReaderAndRexValidations(DoorType.Door2);
            });
        }

        private void Door2ConfigReaderAndRexValidations(DoorType doorType)
        {
            When(o => o.Readers is null, () =>
            {
                RuleFor(r => r.Readers!).Null();
            });

            When(o => o.Rexes is null, () =>
            {
                RuleFor(r => r.Rexes!).Null();
            });

            When(o => o.Readers is not null && o.Readers.Any(), () =>
            {
                RuleForEach(x => x.Readers).SetValidator(new UpdateReaderDTOValidator());

                RuleFor(x => x.Readers.Count()).LessThanOrEqualTo(1).WithMessage(ValidationMessages.DoorTypeDoor1ReadersMustBeLessThanOrEqualTo1);
                if (doorType is DoorType.Door1)
                    RuleFor(o => o.Readers.First().ReaderType).Equal(ReaderType.Reader1);
                else if (doorType is DoorType.Door2)
                    RuleFor(o => o.Readers.First().ReaderType).Equal(ReaderType.Reader2);
            });

            When(o => o.Rexes is not null && o.Rexes.Any(), () =>
            {
                RuleForEach(x => x.Rexes).SetValidator(new UpdateRexDTOValidator());

                RuleFor(x => x.Rexes!.Count()).LessThanOrEqualTo(1).WithMessage(ValidationMessages.DoorTypeDoor1ReadersMustBeLessThanOrEqualTo1);
                if (doorType is DoorType.Door1)
                    RuleFor(o => o.Rexes!.First().RexType).Equal(RexType.Rex1);
                else if (doorType is DoorType.Door2)
                    RuleFor(o => o.Rexes!.First().RexType).Equal(RexType.Rex2);
            });
        }                

        private bool IsDuplicated<T>(IEnumerable<T> listToCheck, Func<T, bool> expression)
        {
            var matchValues = listToCheck.Where(expression);
            if (matchValues.Count() <= 1)
                return true;
            return false;
        }
    }

    public class DeleteDoorDTOValidator : AbstractValidator<DeleteDoorDTO>
    {
        public DeleteDoorDTOValidator()
        {
            RuleFor(o => o.Id).NotNull().GreaterThan(0);
        }
    }
}
