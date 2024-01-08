using Business.DTOs.Request.Question;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateQuestionRequestValidator : AbstractValidator<CreateQuestionRequest>
    {
        public CreateQuestionRequestValidator()
        {
            RuleFor(x => x.ExamId).NotEmpty();
            RuleFor(x => x.Problem).MinimumLength(10);

        }
    }
}
