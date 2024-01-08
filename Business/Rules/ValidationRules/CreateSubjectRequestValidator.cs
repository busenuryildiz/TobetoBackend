using Business.DTOs.Request.Subject;
using Business.DTOs.Request.Survey;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateSubjectRequestValidator : AbstractValidator<CreateSubjectRequest>
    {
        public CreateSubjectRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

        }
    }
}
