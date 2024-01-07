using Business.DTOs.Request.City;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
    {
        public CreateCityRequestValidator()
        {
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId alanı boş olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz.");
          
        }
    }
}
