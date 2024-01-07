using Business.DTOs.Request.EducationInformation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateEducationInformationRequestValidator : AbstractValidator<CreateEducationInformationRequest>
    {
        public CreateEducationInformationRequestValidator()
        {
            RuleFor(education => education.UserId)
               .NotEmpty().WithMessage("UserId boş olamaz.");

            RuleFor(education => education.Status)
                .NotEmpty().WithMessage("Durum boş olamaz.")
                .MaximumLength(255).WithMessage("Durum 255 karakteri geçemez.");

            RuleFor(education => education.University)
                .NotEmpty().WithMessage("Üniversite boş olamaz.")
                .MaximumLength(255).WithMessage("Üniversite 255 karakteri geçemez.");

            RuleFor(education => education.Faculty)
                .NotEmpty().WithMessage("Fakülte boş olamaz.")
                .MaximumLength(255).WithMessage("Fakülte 255 karakteri geçemez.");

            RuleFor(education => education.BeginningYear)
                .NotNull().WithMessage("Başlama Yılı null olamaz.")
                .Must((education, beginningYear) => beginningYear <= education.GraduationYear)
                .WithMessage("Başlama Yılı, Mezuniyet Yılı'ndan küçük veya eşit olmalıdır.");



        }
    }
}
