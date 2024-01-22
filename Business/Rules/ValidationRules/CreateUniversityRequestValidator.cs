using Business.DTOs.Request.University;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateUniversityRequestValidator : AbstractValidator<CreateUniversityRequest>
    {
        public CreateUniversityRequestValidator()
        {
            RuleFor(university => university.Name)
               .NotEmpty().WithMessage("Üniversite adı boş olamaz.")
               .MaximumLength(255).WithMessage("Üniversite adı 255 karakteri geçemez.");

            RuleFor(university => university.Address)
                .NotEmpty().WithMessage("Üniversite adresi boş olamaz.")
                .MaximumLength(500).WithMessage("Üniversite adresi 500 karakteri geçemez.");

            RuleFor(university => university.Website)
                .NotEmpty().WithMessage("Üniversite websitesi boş olamaz.")
                .MaximumLength(255).WithMessage("Üniversite websitesi 255 karakteri geçemez.");

            RuleFor(university => university.Department)
                .NotEmpty().WithMessage("Üniversite bölümü boş olamaz.")
                .MaximumLength(255).WithMessage("Üniversite bölümü 255 karakteri geçemez.");
        }
    }
}
