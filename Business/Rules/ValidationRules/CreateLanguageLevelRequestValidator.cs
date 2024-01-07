using Business.DTOs.Request.LanguageLevel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateLanguageLevelRequestValidator : AbstractValidator<CreateLanguageLevelRequest>
    {
        public CreateLanguageLevelRequestValidator()
        {
            RuleFor(languageLevel => languageLevel.Name)
                .NotEmpty().WithMessage("Dil seviyesi adı boş olamaz.")
                .MaximumLength(255).WithMessage("Dil seviyesi adı 255 karakteri geçemez.");

            
        }
    }
}
