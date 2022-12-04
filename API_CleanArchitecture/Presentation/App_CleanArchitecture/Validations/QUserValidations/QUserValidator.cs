using Domain.Dtos.QUserDtos;
using FluentValidation;
using Microsoft.AspNetCore.Builder.Extensions;
using System.Text.RegularExpressions;

namespace App_CleanArchitecture.Validations.QUserValidations
{
    public class AddQUserValidator : AbstractValidator<ADD_QUser_DTO>
    {
        public AddQUserValidator() {
            
            RuleFor(_ => _.firstName).MaximumLength(maximumLength: 64).NotEmpty();
            RuleFor(_ => _.lastName).MaximumLength(maximumLength: 64).NotEmpty();
            RuleFor(_ => _.middleName).MaximumLength(maximumLength: 64);
            RuleFor(_ => _.employeeId).MaximumLength(maximumLength: 40);
            RuleFor(_ => _.department).MaximumLength(64);
            RuleFor(_ => _.company).MaximumLength(maximumLength: 100);
            RuleFor(_ => _.gender).MaximumLength(maximumLength: 6); 
            RuleFor(_ => _.lastLocation).MaximumLength(maximumLength: 64);
            RuleFor(_ => _.nationality).MaximumLength(100);
            RuleFor(_ => _.email).MaximumLength(254);
            RuleFor(_ => _.qUserType).MaximumLength(64);
            RuleFor(_ => _.phone).MaximumLength(16);

            //card validation

            RuleFor(_ => _.Cards).Custom((list,context) => {

                if (list.Any())
                {
                    Regex reg = new Regex(@"^[0-9]+$");
                    foreach (var item in list)
                    {
                        if (item!.cardNumber!.Length > 255)
                        {
                            context.AddFailure("Card Number length can't be greater than 255");
                        }
                        else {
                            var numbersOnly = reg.Match(item.cardNumber);
                            if (!numbersOnly.Success)
                            {
                                context.AddFailure("Characters are not allowed in Card Number");
                            }
                        }

                        if (item!.cardRaw!.Length > 255)
                        {
                            context.AddFailure("Card Raw length can't be greater than 255");
                        }
                        else {
                            var numbersOnly = reg.Match(item.cardRaw);
                            if (!numbersOnly.Success)
                            {
                                context.AddFailure("Characters are not allowed in Card Raw");
                            }
                        }
                    }
                }
            });

            RuleFor(_ => _.QUserAccessLevels).Custom((list,context) =>
            {
                if(list.Any())
                {
                    foreach (var item in list)
                    {
                        if (item!.AccessLevelId <= 0)
                        {
                            context.AddFailure("Access Level Id can't be equal or less then 0");
                        }

                    }

                }

            });

            //RuleFor(_ => _.qUserFile!.ImageName).MaximumLength(100).Custom((value, context) =>
            //{
            //    if (string.IsNullOrEmpty(value))
            //    {
            //        context.AddFailure("ImageName can't be null");
            //    }
            //});
            //RuleFor(_ => _.qUserFile!.ImageData).Custom((value, context) =>
            //{
            //    if (string.IsNullOrEmpty(value))
            //    {
            //        context.AddFailure("ImageData can't be null");
            //    }
            //});

            RuleFor(_ => _.QUserFile.ImageName).MaximumLength(100)
                .NotEmpty()
                .When(_ => _.QUserFile != null);
            RuleFor(_ => _.QUserFile.ImageData)
                .NotEmpty()
                .When(_ => _.QUserFile != null); 


        } 
    }

    public class UpdateQUserValidator : AbstractValidator<Update_QUser_DTO>
    {
        public UpdateQUserValidator()
        {
            RuleFor(_ => _.Id).NotNull().GreaterThan(0);
            RuleFor(_ => _.firstName).MaximumLength(maximumLength: 64).NotEmpty();
            RuleFor(_ => _.lastName).MaximumLength(maximumLength: 64).NotEmpty();
            RuleFor(_ => _.middleName).MaximumLength(maximumLength: 64);
            RuleFor(_ => _.employeeId).MaximumLength(maximumLength: 40);
            RuleFor(_ => _.department).MaximumLength(64);
            RuleFor(_ => _.company).MaximumLength(maximumLength: 100);
            RuleFor(_ => _.gender).MaximumLength(maximumLength: 6);
            RuleFor(_ => _.lastLocation).MaximumLength(maximumLength: 64);
            RuleFor(_ => _.nationality).MaximumLength(100);
            RuleFor(_ => _.email).MaximumLength(254);
            RuleFor(_ => _.qUserType).MaximumLength(64);
            RuleFor(_ => _.phone).MaximumLength(16);

            //card validation

            RuleFor(_ => _.Cards).Custom((list, context) => {

                if (list.Any())
                {
                    Regex reg = new Regex(@"^[0-9]+$");
                    foreach (var item in list)
                    {
                        if (item!.cardNumber!.Length > 255)
                        {
                            context.AddFailure("Card Number length can't be greater than 255");
                        }
                        else
                        {
                            var numbersOnly = reg.Match(item.cardNumber);
                            if (!numbersOnly.Success)
                            {
                                context.AddFailure("Characters are not allowed in Card Number");
                            }
                        }
                        if (item!.cardRaw!.Length > 255)
                        {
                            context.AddFailure("Card Raw length can't be greater than 255");
                        }
                        else
                        {
                            var numbersOnly = reg.Match(item.cardRaw);
                            if (!numbersOnly.Success)
                            {
                                context.AddFailure("Characters are not allowed in Card Raw");
                            }
                        }
                    }
                }
            });


            RuleFor(_ => _.QUserAccessLevels).Custom((list, context) =>
            {
                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        if (item!.AccessLevelId <= 0)
                        {
                            context.AddFailure("Access Level Id can't be equal or less then 0");
                        }

                    }

                }

            });

            RuleFor(_ => _.QUserFile.ImageName).MaximumLength(100)
              .NotEmpty()
              .When(_ => _.QUserFile != null);
            RuleFor(_ => _.QUserFile.ImageData)
                .NotEmpty()
                .When(_ => _.QUserFile != null);

        }
    }

    public class DeleteQUserValidator : AbstractValidator<Delete_QUser_DTO>
    {
        public DeleteQUserValidator()
        {
            RuleFor(_ => _.Id).NotNull().GreaterThan(0);
        }
    }
}
