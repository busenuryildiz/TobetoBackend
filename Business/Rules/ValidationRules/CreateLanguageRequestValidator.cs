using Business.DTOs.Request.Language;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateLanguageRequestValidator : AbstractValidator<CreateLanguageRequest>
    {
        public CreateLanguageRequestValidator()
        {
            
            RuleFor(language => language.Name)
                  .NotEmpty().WithMessage("Dil adı boş olamaz.")
                  .MaximumLength(255).WithMessage("Dil adı 255 karakteri geçemez.");

            

        }
    }
}
