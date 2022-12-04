namespace App_CleanArchitecture.Validations;

using Domain.Dtos;

using FluentValidation;

public class AddAreaDTOValidator : AbstractValidator<AddAreaDto>
{
    public AddAreaDTOValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty().MaximumLength(64);
    }
}
public class UpdateAreaDTOValidator : AbstractValidator<AddAreaDto>
{
    public UpdateAreaDTOValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty().MaximumLength(64);
    }
}
