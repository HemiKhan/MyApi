namespace App_CleanArchitecture.Validations.ScheduleValidations;

using Domain.Dtos.Schedule.ScheduleItemsDtos;

using FluentValidation;

public class AddScheduleItemDTOValidator : AbstractValidator<AddScheduleItemDto>
{
    public AddScheduleItemDTOValidator()
    {
        RuleFor(_ => _.ScheduleId).NotNull().NotEmpty();
        RuleFor(_ => _.Summary).NotNull().NotEmpty().MaximumLength(64);
        RuleFor(_ => _.RecurrenceDays).NotEmpty().When(_ => _.IsRecurrence && _.IsWeekly);
        RuleFor(_ => _.StartTime).NotEmpty().MaximumLength(5).MinimumLength(5).When(_ => _.IsAllDay is false).WithMessage("Invalid Time");
        RuleFor(_ => _.EndTime).NotEmpty().MaximumLength(5).MinimumLength(5).When(_ => _.IsAllDay is false).WithMessage("Invalid Time");
        RuleFor(_ => _.EndBy).NotNull().When(_ => _.IsEndBy is true);
        RuleFor(_ => _.EndDate).NotNull().When(_ => _.IsRecurrence is false && _.IsAllDay is false);
    }
}


public class UpdateScheduleItemDTOValidator : AbstractValidator<UpdateScheduleItemDto>
{
    public UpdateScheduleItemDTOValidator()
    {

        RuleFor(_ => _.Id).NotNull().NotEmpty();
        RuleFor(_ => _.ScheduleId).NotNull().NotEmpty();
        RuleFor(_ => _.Summary).NotNull().NotEmpty().MaximumLength(64);
        RuleFor(_ => _.RecurrenceDays).NotEmpty().When(_ => _.IsRecurrence && _.IsWeekly);
        RuleFor(_ => _.StartTime).NotEmpty().MaximumLength(5).MinimumLength(5).When(_ => _.IsAllDay is false).WithMessage("Invalid Time");
        RuleFor(_ => _.EndTime).NotEmpty().MaximumLength(5).MinimumLength(5).When(_ => _.IsAllDay is false).WithMessage("Invalid Time");
        RuleFor(_ => _.EndBy).NotNull().When(_ => _.IsEndBy is true);
        //RuleFor(_ => _.EndDate).NotNull().When(_ => _.IsAllDay is false);
        RuleFor(_ => _.EndDate).NotNull().When(_ => _.IsRecurrence is false && _.IsAllDay is false);
    }
}
