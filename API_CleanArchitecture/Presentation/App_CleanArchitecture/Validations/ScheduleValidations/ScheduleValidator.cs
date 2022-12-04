namespace App_CleanArchitecture.Validations.ScheduleValidations;

using Domain.Dtos;

using FluentValidation;

public class AddScheduleDTOValidator : AbstractValidator<AddScheduleDTO>
{
    public AddScheduleDTOValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().MaximumLength(64);
        RuleFor(_ => _.Description).MaximumLength(128);
    }
}


public class UpdateScheduleDTOValidator : AbstractValidator<UpdateScheduleDTO>
{
    public UpdateScheduleDTOValidator()
    {

        RuleFor(_ => _.Id).NotEmpty().NotNull();
        RuleFor(_ => _.Name).NotEmpty().MaximumLength(64);
        RuleFor(_ => _.Description).MaximumLength(128);
    }
}
