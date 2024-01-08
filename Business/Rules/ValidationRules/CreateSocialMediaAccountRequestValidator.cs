using Business.DTOs.Request.SocialMediaAccount;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateSocialMediaAccountRequestValidator : AbstractValidator<CreateSocialMediaAccountRequest>
    {
        public CreateSocialMediaAccountRequestValidator()
        {
            RuleFor(socialMediaAccount => socialMediaAccount.UserId)
                .NotEmpty().WithMessage("UserId boş olamaz.");

            RuleFor(socialMediaAccount => socialMediaAccount.SocialMedia)
                .NotEmpty().WithMessage("Sosyal medya adı boş olamaz.")
                .MaximumLength(255).WithMessage("Sosyal medya adı 255 karakteri geçemez.");

            RuleFor(socialMediaAccount => socialMediaAccount.SocialMediaUrl)
                .NotEmpty().WithMessage("Sosyal medya URL'si boş olamaz.")
                .MaximumLength(500).WithMessage("Sosyal medya URL'si 500 karakteri geçemez.");
                

        }
    }
}
