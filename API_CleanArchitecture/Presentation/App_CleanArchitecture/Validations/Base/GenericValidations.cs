namespace App_CleanArchitecture.Validations.Base;

using Application.Handlers;

using FluentValidation;

public class GetAllDtoValidatior : AbstractValidator<GetAllParams>
{
    public GetAllDtoValidatior()
    {
        RuleFor(_ => _.SearchValue).MinimumLength(3).ShouldNotStartWithNumber();
    }
}

public abstract class BaseValidator<T> : AbstractValidator<T>  
    where T : class
{
    public BaseValidator()
    {
            
    }
}
