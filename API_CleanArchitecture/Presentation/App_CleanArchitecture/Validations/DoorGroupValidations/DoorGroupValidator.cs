namespace App_CleanArchitecture.Validations.DoorGroupValidations;

using Domain.Dtos.DoorGroupDtos;

using FluentValidation;

public class AddDoorGroupValidator : AbstractValidator<AddDoorGroupDto>
{
    public AddDoorGroupValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().NotNull().MaximumLength(64);
        RuleFor(_ => _.DoorId).Custom((list, context) =>
        {
            if (list.Select(id => id).Distinct().Count() != list.Count())
            {
                context.AddFailure("Door Ids should be different");
            }
        });
    }
}
public class UpdateDoorGroupValidator : AbstractValidator<UpdateDoorGroupDto>
{
    public UpdateDoorGroupValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().NotNull().MaximumLength(64);
        RuleFor(_ => _.DGD).Custom((list, context) =>
        {
            if (list.Select(x => x.DoorId).Distinct().Count() != list.Count())
            {
                context.AddFailure("Door Ids should be different");
            }
        });
    }
}
