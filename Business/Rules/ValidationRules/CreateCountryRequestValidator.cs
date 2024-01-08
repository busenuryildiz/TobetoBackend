using Business.DTOs.Request.Country;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateCountryRequestValidator : AbstractValidator<CreateCountryRequest>
    {
        public CreateCountryRequestValidator()
        {
         
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name alanı boş olamaz.");


        }
    }
}
