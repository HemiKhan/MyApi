namespace App_CleanArchitecture.Validations.ControllerValidations;

using Domain.Dtos.ControllerDTOs;

using FluentValidation;

public class AddControllerDTOValidator : AbstractValidator<AddControllerCommand>
{
    public AddControllerDTOValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().MaximumLength(64);
        RuleFor(_ => _.UserName).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(_ => _.Password).NotEmpty().MaximumLength(100);
        RuleFor(_ => _.MACAddress).NotEmpty().NotNull(); 
        RuleFor(_ => _.OAK).NotEmpty().MaximumLength(75);
        RuleFor(_ => _.IsOneDoor).NotNull();
        //RuleFor(_ => _.Entity).NotEmpty().MaximumLength(15);
        //RuleFor(_ => _.MACAddress).NotEmpty().MaximumLength(17).Matches(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$"); // 3D:F2:C9:A6:B3:4F mac validiton
    }
}


public class UpdateControllerDTOValidator : AbstractValidator<Update_ControllerDTO>
{
    public UpdateControllerDTOValidator()
    {
        RuleFor(_ => _.Id).NotEmpty();
        RuleFor(_ => _.Name).NotEmpty().MaximumLength(64);
        RuleFor(_ => _.UserName).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(_ => _.Password).MaximumLength(100);
        RuleFor(_ => _.MACAddress).NotEmpty().NotNull();
        RuleFor(_ => _.OAK).NotEmpty().MaximumLength(75);
        RuleFor(_ => _.IsOneDoor).NotNull();
        //RuleFor(_ => _.ControllerModel).NotEmpty().MaximumLength(15);
        //RuleFor(_ => _.MACAddress).NotEmpty().MaximumLength(17).Matches(@"^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$");
    }
}


