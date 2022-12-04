namespace App_CleanArchitecture.Validations;

using Domain.Dtos;
using Domain.Dtos.OutputSensorDTOs;

using FluentValidation;

public class ControllerIoPortsValidator : AbstractValidator<Update_ControllerIoPorts_Dto>
{
    public ControllerIoPortsValidator()
    {
        RuleFor(_ => _.Name).NotNull().NotEmpty().MaximumLength(64);
        RuleFor(_ => _.ControllerId).GreaterThanOrEqualTo(1);
        RuleFor(_ => _.State).NotEmpty().NotNull();
        RuleFor(_ => _.PortType).NotEmpty().NotNull();
    }
}