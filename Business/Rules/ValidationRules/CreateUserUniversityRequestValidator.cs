using Business.DTOs.Request.UserUniversity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateUserUniversityRequestValidator : AbstractValidator<CreateUserUniversityRequest>
    {
        public CreateUserUniversityRequestValidator()
        {
            RuleFor(userUniversity => userUniversity.UserId)
                   .NotEmpty().WithMessage("UserId boş olamaz.");

            RuleFor(userUniversity => userUniversity.UniversityId)
                .GreaterThan(0).WithMessage("UniversityId 0'dan büyük olmalıdır.");
        }
    }
}
