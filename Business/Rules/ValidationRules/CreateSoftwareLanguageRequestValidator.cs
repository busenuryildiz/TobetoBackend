using Business.DTOs.Request.SoftwareLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateSoftwareLanguageRequestValidator : AbstractValidator<CreateSoftwareLanguageRequest>
    {
        public CreateSoftwareLanguageRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}
