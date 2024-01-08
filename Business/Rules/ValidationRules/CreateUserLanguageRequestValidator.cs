using Business.DTOs.Request.UserLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateUserLanguageRequestValidator : AbstractValidator<CreateUserLanguageRequest>
    {
        public CreateUserLanguageRequestValidator()
        {
            RuleFor(userLanguage => userLanguage.UserId)
                .NotEmpty().WithMessage("UserId boş olamaz.");

            RuleFor(userLanguage => userLanguage.LanguageId)
                .GreaterThan(0).WithMessage("LanguageId 0'dan büyük olmalıdır.");

            RuleFor(userLanguage => userLanguage.LanguageLevelId)
                .GreaterThan(0).WithMessage("LanguageLevelId 0'dan büyük olmalıdır.");

        }
    }
}
