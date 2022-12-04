namespace App_CleanArchitecture.Validations.Base;

using FluentValidation;
using FluentValidation.Validators;


public class ShouldNotStartWithNumber<T, TProperty> : PropertyValidator<T, TProperty>
{


  public ShouldNotStartWithNumber()
  {
  }

  public override bool IsValid(ValidationContext<T> context, TProperty property)
  {
    return !char.IsNumber(context.InstanceToValidate!.ToString()![0]);
  }

  public override string Name => "ShouldNotStartWithNumber";

  protected override string GetDefaultMessageTemplate(string errorCode)
    => "{PropertyName} must not start with number";
}
