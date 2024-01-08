using Business.DTOs.Request.District;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateDistrictRequestValidator : AbstractValidator<CreateDistrictRequest>
    {
        public CreateDistrictRequestValidator()
        {
            RuleFor(district => district.CityId)
               .GreaterThan(0).WithMessage("CityId must be greater than 0.");

            RuleFor(district => district.Name)
                .NotEmpty().WithMessage("District Name cannot be empty.")
                .MaximumLength(255).WithMessage("District Name cannot exceed 255 characters.");


            

        }
    }
}
