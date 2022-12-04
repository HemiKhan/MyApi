namespace App_CleanArchitecture.Validations.Reader
{
    using Domain.Constants;
    using Domain.Dtos.ControllerDTOs.DoorDTOs.ReaderDTOs;
    using Domain.Dtos.ReaderDTOs;

    using FluentValidation;

    public class AddReaderDTOValidator : AbstractValidator<AddReaderDTO>
    {
        public AddReaderDTOValidator()
        {
            RuleFor(o => o.Name).MaximumLength(45).NotNull().NotEmpty();
            RuleFor(o => o.Description).MaximumLength(60);
            RuleFor(o => o.Location).MaximumLength(60);
            RuleFor(o => o.LPNCameraSN).MaximumLength(50);
            RuleFor(o => o.HeartbeatInterval).GreaterThanOrEqualTo(0);
            RuleFor(o => o.Timeout).GreaterThanOrEqualTo(0);
           
            RuleFor(o => o.AreaInId).NotEqual(0);
            RuleFor(o => o.AreaOutId).NotEqual(0);

            RuleFor(x => x.ReaderType).Must(x => Enum.IsDefined(typeof(ReaderType), x));

            RuleFor(x => x.ReaderIdentificationType).NotNull().NotEmpty();
            When(o => o.ReaderIdentificationType is not null && o.ReaderIdentificationType!.Any(), () =>
            {
                RuleForEach(x => x.ReaderIdentificationType).SetValidator(new ReaderIdentificationTypeDTOValidator());
                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.FacilityCodeOnly))
                .WithMessage("ReaderIdentification Type FacilityCodeOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardNumberOnly))
                .WithMessage("ReaderIdentification Type CardNumberOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardRawOnly))
                .WithMessage("ReaderIdentification Type CardRawOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.PINOnly))
                .WithMessage("ReaderIdentification Type PINOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardRawAndPIN))
                .WithMessage("ReaderIdentification Type CardRawAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.FacilityCodeAndPIN))
                .WithMessage("ReaderIdentification Type FacilityCodeAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardNumberAndPIN))
                .WithMessage("ReaderIdentification Type CardNumberAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.LicensePlateOnly))
                .WithMessage("ReaderIdentification Type LicensePlateOnly Already Exsits");
            });

            RuleFor(x => x.Protocol).Must(x => Enum.IsDefined(typeof(ReaderProtocol), x));
            When(o => o.Protocol is ReaderProtocol.OSDP, () =>
            {
                RuleFor(o => o.LEDType).Null().Empty();
            });
            When(o => o.Protocol is ReaderProtocol.Wiegand, () =>
            {
                RuleFor(o => o.LEDType).NotNull().NotEmpty();
            });
        }
        private bool IsDuplicated<T>(IEnumerable<T> listToCheck, Func<T, bool> expression)
        {
            var matchValues = listToCheck.Where(expression);
            var matchValuesCount = matchValues.Count();
            if (matchValuesCount <= 1)
                return true;
            return false;
        }
    }

    public class ReaderIdentificationTypeDTOValidator : AbstractValidator<ReaderIdentificationTypeDTO>
    {
        public ReaderIdentificationTypeDTOValidator()
        {
            RuleFor(_ => _.IdentificationType).Must(x => Enum.IsDefined(typeof(IdentificationType), x)).NotNull();
            RuleFor(o => o.DuringScheduleId).NotNull().NotEmpty();
            RuleFor(o => o.ExceptScheduleId).NotEqual(0);
        }
    }

    public class UpdateReaderDTOValidator : AbstractValidator<Reader_GetById_DTO>
    {
        public UpdateReaderDTOValidator()
        {
            RuleFor(x => x.Id).NotEqual(0);
            RuleFor(o => o.Name).MaximumLength(45).NotNull().NotEmpty();
            RuleFor(o => o.Description).MaximumLength(60);
            RuleFor(o => o.Location).MaximumLength(60);
            RuleFor(o => o.LPNCameraSN).MaximumLength(50);
            RuleFor(o => o.HeartbeatInterval).GreaterThanOrEqualTo(0);
            RuleFor(o => o.Timeout).GreaterThanOrEqualTo(0);

            RuleFor(o => o.AreaInId).NotEqual(0);
            RuleFor(o => o.AreaOutId).NotEqual(0);

            RuleFor(x => x.ReaderType).Must(x => Enum.IsDefined(typeof(ReaderType), x));

            RuleFor(x => x.ReaderIdentificationType).NotNull().NotEmpty();
            When(o => o.ReaderIdentificationType is not null && o.ReaderIdentificationType!.Any(), () =>
            {
                RuleForEach(x => x.ReaderIdentificationType).SetValidator(new ReaderIdentificationTypeDTOValidator());
                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.FacilityCodeOnly))
                .WithMessage("ReaderIdentification Type FacilityCodeOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardNumberOnly))
                .WithMessage("ReaderIdentification Type CardNumberOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardRawOnly))
                .WithMessage("ReaderIdentification Type CardRawOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.PINOnly))
                .WithMessage("ReaderIdentification Type PINOnly Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardRawAndPIN))
                .WithMessage("ReaderIdentification Type CardRawAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.FacilityCodeAndPIN))
                .WithMessage("ReaderIdentification Type FacilityCodeAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.CardNumberAndPIN))
                .WithMessage("ReaderIdentification Type CardNumberAndPIN Already Exsits");

                RuleFor(x => x.ReaderIdentificationType)
                .Must((x, type) => IsDuplicated(x.ReaderIdentificationType!, _ => _.IdentificationType == IdentificationType.LicensePlateOnly))
                .WithMessage("ReaderIdentification Type LicensePlateOnly Already Exsits");
            });

            RuleFor(x => x.Protocol).Must(x => Enum.IsDefined(typeof(ReaderProtocol), x));
            When(o => o.Protocol is ReaderProtocol.OSDP, () =>
            {
                RuleFor(o => o.LEDType).Null().Empty();
            });
            When(o => o.Protocol is ReaderProtocol.Wiegand, () =>
            {
                RuleFor(o => o.LEDType).NotNull().NotEmpty();
            });
        }

        private bool IsDuplicated<T>(IEnumerable<T> listToCheck, Func<T, bool> expression)
        {
            var matchValues = listToCheck.Where(expression);
            var matchValuesCount = matchValues.Count();
            if (matchValuesCount <= 1)
                return true;
            return false;
        }
    }

    public class DeleteReaderDTOValidator : AbstractValidator<DeleteReaderDTO>
    {
        public DeleteReaderDTOValidator()
        {
            RuleFor(p => p.Id).NotEmpty().GreaterThan(0);
        }
    }
}
