namespace App_CleanArchitecture.Validations.AccessLevelValidations;

using Domain.Dtos;
using Domain.Dtos.AccessLevelDTOs;
using Domain.Exceptions;
using FluentValidation;

public class AddAccessLevelValidator : AbstractValidator<Add_AccessLevel_DTO>
{
	public AddAccessLevelValidator()
	{
		RuleFor(_=> _.ScheduleId).NotEmpty(); 
		RuleFor(_=> _.Name).MaximumLength(65).NotEmpty();
		RuleFor(_ => _.ScheduleId).NotEmpty().GreaterThan(0);
        RuleFor(_ => _.ExceptScheduleId)
           .Custom((ESID, context) =>
           {
               if (ESID is not null && ESID <= 0)
                   context.AddFailure($"Access Level ExceptScheduleId {ESID} is not valid");
           });
        RuleFor(_ => _.AccessLevelDoors).Custom((list, context) =>
		{
            int Iterations = 0;
			foreach(var item in list)
			{

                if (item.ScheduleId is <= 0)
                    context.AddFailure("DuringScheduleId Cannot be null");
				if(item.ExceptScheduleId is <= 0)
                    context.AddFailure("ExceptScheduleId Cannot be null");
                if (item.DoorId is <= 0)
                    context.AddFailure("DoorId Cannot be null");
                Iterations = Iterations + 1;
            }
            Iterations = 0;
            if (list.Select(x => x.DoorId).Distinct().Count() != list.Count())
            {
                context.AddFailure("Door Ids should be different");
            }
        });
    }
}


public class UpdateAccessLevelValidator : AbstractValidator<Update_AccessLevel_DTO>
{
	public UpdateAccessLevelValidator()
	{
        RuleFor(_ => _.Id).NotNull().GreaterThan(0);
        RuleFor(_ => _.ScheduleId).NotEmpty();
        RuleFor(_ => _.Name).MaximumLength(65).NotEmpty();
        RuleFor(_ => _.ScheduleId).NotEmpty().GreaterThan(0);
        RuleFor(_ => _.ExceptScheduleId)
            .Custom((ESID,context) =>
            {
                if (ESID is not null && ESID <= 0)
                   context.AddFailure("ExceptScheduleId is not valid");
        });
        RuleFor(_ => _.AccessLevelDoors)
            .Custom((list, context) =>
        {
            int Iterations = 0;
            foreach (var item in list)
            {
                if (item.Id is not null && item.Id <= 0)
                    context.AddFailure($"AccessLevelDoorId {item.Id} is not valid, Index = {Iterations}");
                if (item.ScheduleId is <= 0)
                    throw new QException("DuringScheduleId Cannot be null");
                if (item.ExceptScheduleId is <= 0)
                    throw new QException("ExceptScheduleId Cannot be null");
            }
            Iterations = 0;
            var newList = list.Where(x => x.Id is not null);

            if(newList.Select(_=> _.Id).Distinct().Count() != newList.Count())
                context.AddFailure("Duplicate Access Level Doors Are Not Allowed");
            if (list.Select(x => x.DoorId).Distinct().Count() != list.Count())
                context.AddFailure("Door Ids should be different");
        });
    }
}

public class DeleteAccessLevelValidator : AbstractValidator<Delete_AccessLevel_DTO>
{
    public DeleteAccessLevelValidator()
    {
        RuleFor(_ => _.Id).NotNull().GreaterThan(0);
    }
}