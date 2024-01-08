using Business.DTOs.Request.Address;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
    {
        public CreateAddressRequestValidator()
        {

            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId alanı boş olamaz.");
            RuleFor(x => x.DistrictId).NotEmpty().WithMessage("DistrictId alanı boş olamaz.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz.");
            //RuleFor(x => x.AboutMe).MinimumLength(20).WithMessage("AboutMe en az 20 karakter uzunluğunda olmalıdır.");


        }




    }
}


