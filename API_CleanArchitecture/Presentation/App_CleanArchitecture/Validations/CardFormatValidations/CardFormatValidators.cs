namespace App_CleanArchitecture.Validations.CardFormatValidations;

using Domain.Dtos;
using Domain.Dtos.CardFormatDtos;
using Domain.Exceptions;

using AutoWrapper.Extensions;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//using static System.Runtime.InteropServices.JavaScript.JSType;

public class AddCardFormatDtoValidator : AbstractValidator<AddCardFormatDto>
{
    public AddCardFormatDtoValidator()
    {
        RuleFor(_ => _.Name).NotEmpty().NotNull().MaximumLength(64);
        RuleFor(_ => _.Name).Matches("^[^:;<>{}]*$").WithMessage("\":;<>{} not allowed");
        RuleFor(_ => _.Description).MaximumLength(64);
        RuleFor(_ => _.Description).Matches("^[^:;<>{}]*$").WithMessage("\":;<>{} not allowed");
        RuleFor(_ => _.BitLength).GreaterThan(0).LessThanOrEqualTo(1000000000);
        RuleFor(x => x.CardFormatItems).Custom((list, context) =>
        {
            if (list.Any())
            {

                var duplicat = new List<string>();
                foreach (var item in list!)
                {
                    if (!Regex.IsMatch(item.FieldMapName, "^[^\"{}<>:;]*$"))
                        context.AddFailure("Invalid Name");
                    if (!duplicat.Any(p => p == item.FieldMapName))
                    {
                        duplicat.Add(item.FieldMapName);
                    }
                    else
                    {
                        context.AddFailure("FieldMapName cannot be duplicate");
                    }
                    if (!Regex.IsMatch(item.EncodingRange, "^[0-9]+(-[0-9]+)?$"))
                        context.AddFailure("EncodingRange Incorrect Format");
                    var splited = item.EncodingRange.Split("-");
                    var firstindex = splited.First().ToInt32();
                    var lastindex = splited.Last().ToInt32();
                    if (lastindex < firstindex || firstindex == 0)
                        context.AddFailure("Range error");
                    if (string.IsNullOrEmpty(item.FieldMapName))
                        context.AddFailure("FieldMapName must not be empty!");
                    if (item.FieldMapName.Length > 64)
                        context.AddFailure("FieldMapName length not greater than 64!");
                    if (string.IsNullOrEmpty(item.EncodingRange))
                        context.AddFailure("EncodingRange must not be empty!");
                    if (string.IsNullOrEmpty(item.Encoding))
                        context.AddFailure("Encoding must not be empty!");
                    if (item.Encoding.Length > 13)
                        context.AddFailure("Encoding length not greater than 13!");
                }
            }
        });

    }
}

public class UpdateCardFormatDtoValidator : AbstractValidator<UpdateCardFormatDto>
{
    public UpdateCardFormatDtoValidator()
    {
        RuleFor(_ => _.Id).NotEmpty().NotNull();
        RuleFor(_ => _.Name).NotEmpty().NotNull().MaximumLength(64);
        RuleFor(_ => _.Name).Matches("^[^:;<>{}]*$").WithMessage("\":;<>{} not allowed");
        RuleFor(_ => _.Description).MaximumLength(64);
        RuleFor(_ => _.Description).Matches("^[^:;<>{}]*$").WithMessage("\":;<>{} not allowed");
        RuleFor(_ => _.BitLength).GreaterThan(0).LessThanOrEqualTo(1000000000);
        RuleFor(x => x.CardFormatItems).Custom((list, context) =>
        {
            if (list.Any())
            {
                var duplicat = new List<string>();
                foreach (var item in list!)
                {
                    if (!Regex.IsMatch(item.FieldMapName, "^[^\"{}<>:;]*$"))
                        context.AddFailure("Invalid Name");
                    if (!duplicat.Any(p => p == item.FieldMapName))
                    {
                        duplicat.Add(item.FieldMapName);
                    }
                    else
                    {
                        context.AddFailure("FieldMapName cannot be duplicate");
                    }
                    if (!Regex.IsMatch(item.EncodingRange, "^[0-9]+(-[0-9]+)?$"))
                        context.AddFailure("EncodingRange Incorrect Format");
                    var splited = item.EncodingRange.Split("-");
                    var firstindex = splited.First().ToInt32();
                    var lastindex = splited.Last().ToInt32();
                    if (lastindex < firstindex || firstindex == 0)
                        context.AddFailure("Range error");
                    if (string.IsNullOrEmpty(item.FieldMapName))
                        context.AddFailure("FieldMapName must not be empty!");
                    if (item.FieldMapName.Length > 64)
                        context.AddFailure("FieldMapName length not greater than 64!");
                    if (string.IsNullOrEmpty(item.EncodingRange))
                        context.AddFailure("EncodingRange must not be empty!");
                    if (string.IsNullOrEmpty(item.Encoding))
                        context.AddFailure("Encoding must not be empty!");
                    if (string.IsNullOrEmpty(item.Encoding))
                        context.AddFailure("Encoding length not greater than 13!");
                }
            }
        });
    }
}