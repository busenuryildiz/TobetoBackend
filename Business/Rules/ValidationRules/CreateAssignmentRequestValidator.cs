using Business.DTOs.Request.Assignments;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateAssignmentRequestValidator : AbstractValidator<CreateAssignmentRequest>
    {
        public CreateAssignmentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();


            RuleFor(x => x.Description).MinimumLength(10);

        }
    }
}
