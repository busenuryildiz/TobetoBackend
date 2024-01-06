using Business.DTOs.Request.Option;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateOptionRequestValidator : AbstractValidator<CreateOptionRequest>
    {
        public CreateOptionRequestValidator()
        {
            RuleFor(x => x.IsCorrect).NotEmpty();


            RuleFor(x => x.Answer).MinimumLength(10);

        }
    }
}
