namespace App_CleanArchitecture.Validations.PrioritiesValidations;

using App_CleanArchitecture.Validations.Base;
using Domain.Dtos.PrioritiesDTOs;
using FluentValidation;
using System.Text.RegularExpressions;

public class AddPrioritiesDTOValidator : AbstractValidator<AddPriorityDTO>
{
	public AddPrioritiesDTOValidator()
	{
		RuleFor(o=> o.Name).NotEmpty().MaximumLength(64).Custom((name, context) =>
        {
            string nameFormat = "^([a-zA-Z0-9 _]*)$";
            if (!Regex.IsMatch(name, nameFormat))
                context.AddFailure("Special Characters are Not Allowed");
        });
		RuleFor(o=> o.PriorityLevel).NotEmpty().GreaterThan(0).LessThan(101);
		RuleFor(o=> o.ColorCode).NotEmpty().MaximumLength(10).Custom((c,context) =>
        {
            string ColorCodeFormat = "^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";
            if (!Regex.IsMatch(c, ColorCodeFormat))
                context.AddFailure("Color Code is not Valid");
        });	
    }
}


public class UpdatePrioritiesDTOValidator : AbstractValidator<UpdatePriorityDTO>
{
    public UpdatePrioritiesDTOValidator()
    {
        RuleFor(o => o.Id).GreaterThan(-1);
        RuleFor(o => o.Name).NotEmpty().MaximumLength(64);
        RuleFor(o => o.PriorityLevel).NotEmpty().GreaterThan(-1).LessThan(101);
        RuleFor(o => o.ColorCode).NotEmpty().MaximumLength(10);
    }
}

public class DeletePrioritiesDTOValidator : AbstractValidator<DeletePriorityDTO>
{
    public DeletePrioritiesDTOValidator()
    {
        RuleFor(o => o.Id).GreaterThan(0);
    }
}