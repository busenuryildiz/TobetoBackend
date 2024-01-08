using Business.DTOs.Request.Certificate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateCertificateRequestValidator : AbstractValidator<CreateCertificateRequest>
    {
        public CreateCertificateRequestValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId alanı boş olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz.");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("ImagePath alanı boş olamaz.");
         

        }
    }
}
