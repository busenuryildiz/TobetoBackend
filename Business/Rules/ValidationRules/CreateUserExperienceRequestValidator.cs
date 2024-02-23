using Business.DTOs.Request.UserExperience;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateUserExperienceRequestValidator : AbstractValidator<CreateUserExperienceRequest>
    {
        public CreateUserExperienceRequestValidator()
        {
            RuleFor(experience => experience.UserId)
                .NotEmpty().WithMessage("UserId boş olamaz.");

            RuleFor(experience => experience.EstablishmentName)
                .NotEmpty().WithMessage("Kurum adı boş olamaz.")
                .MaximumLength(255).WithMessage("Kurum adı 255 karakteri geçemez.");

            RuleFor(experience => experience.Position)
                .NotEmpty().WithMessage("Pozisyon boş olamaz.")
                .MaximumLength(255).WithMessage("Pozisyon 255 karakteri geçemez.");

            RuleFor(experience => experience.Sector)
                .NotEmpty().WithMessage("Sektör boş olamaz.")
                .MaximumLength(255).WithMessage("Sektör 255 karakteri geçemez.");

            RuleFor(experience => experience.City)
                .NotEmpty().WithMessage("Şehir boş olamaz.")
                .MaximumLength(255).WithMessage("Şehir 255 karakteri geçemez.");

            RuleFor(experience => experience.WorkBeginDate)
                .NotEmpty().WithMessage("İşe başlama tarihi boş olamaz.")
                .Must((experience, workBeginDate) => workBeginDate <= experience.WorkEndDate)
                .WithMessage("İşe başlama tarihi, bitiş tarihinden küçük veya eşit olmalıdır.");

            RuleFor(experience => experience.WorkEndDate)
                .NotEmpty().WithMessage("İşten ayrılma tarihi boş olamaz.")
                .Must((experience, workEndDate) => workEndDate >= experience.WorkBeginDate)
                .WithMessage("İşten ayrılma tarihi, işe başlama tarihinden büyük veya eşit olmalıdır.");

            
        }
    }
}
