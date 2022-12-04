using Domain.Dtos.QUserDtos;
using Domain.Dtos.QUserDtos.QUserFileDTOs;
using FluentValidation;

namespace App_CleanArchitecture.Validations.QUserValidations.QUserFileValidations
{
    public class QUserFileValidator : AbstractValidator<Add_QUserFile_DTO>
    {
        public QUserFileValidator()
        {

            RuleFor(_ => _.ImageName).MaximumLength(100).NotEmpty();
            RuleFor(_ => _.ImageData).NotEmpty();
        }
    }
}
