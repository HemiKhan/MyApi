namespace App_CleanArchitecture.Validations.ControllerValidations.DoorValidations.RexValidations;

using Domain.Constants;
using Domain.Dtos.ControllerDTOs.DoorDTOs.RexDTOs;

using FluentValidation;

public class AddRexDTOValidator : AbstractValidator<Rex_Add_DTO>
{
    public AddRexDTOValidator()
    {
        RuleFor(x => x.RexType).Must(x => Enum.IsDefined(typeof(RexType), x));
        RuleFor(x => x.RexDuringScheduleId).NotNull().NotEmpty();
        RuleFor(o => o.RexExceptScheduleId).NotEqual(0);
    }
}

public class UpdateRexDTOValidator : AbstractValidator<Rex_GetById_DTO>
{
    public UpdateRexDTOValidator()
    {
        RuleFor(x => x.Id).NotEqual(0);
        RuleFor(x => x.RexType).Must(x => Enum.IsDefined(typeof(RexType), x));
        RuleFor(x => x.RexDuringScheduleId).NotNull().NotEmpty();
        RuleFor(o => o.RexExceptScheduleId).NotEqual(0);
    }
}

public class DeleteDTOValidator : AbstractValidator<DeleteRexDTO>
{
    public DeleteDTOValidator()
    {
        RuleFor(o => o.Id).NotEmpty().GreaterThan(0);
    }
}