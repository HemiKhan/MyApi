namespace App_CleanArchitecture.Validations.ControllerDateTimeSettingValidation;

using Domain.Dtos.TimeZoneSettingDtos;

using FluentValidation;



public class UpdateControllerDateTimeSettingDtoValidator : AbstractValidator<UpdateControllerDateTimeSettingDto>
{
    public UpdateControllerDateTimeSettingDtoValidator()
    {

        RuleFor(_ => _.TimeZoneValue).NotEmpty().NotNull();
        //RuleFor(_ => _.Date).NotEmpty().NotNull().When(_ => _.SetMode is Domain.Constants.SetMode.Manual);
        //RuleFor(_ => _.Time).NotEmpty().NotNull().When(_ => _.SetMode is Domain.Constants.SetMode.Manual);
        //RuleFor(_ => _.IPAddress).NotEmpty().NotNull().When(_ => _.SetMode is Domain.Constants.SetMode.NTP);
    }
}