using Business.DTOs.Request.Exam;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateExamRequestValidator : AbstractValidator<CreateExamRequest>
    {
        public CreateExamRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(10);
            RuleFor(x => x.Point).InclusiveBetween(1, 100);

        }
    }
}
