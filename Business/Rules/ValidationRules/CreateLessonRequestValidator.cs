using Business.DTOs.Request.Lesson;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateLessonRequestValidator : AbstractValidator<CreateLessonRequest>
    {
        public CreateLessonRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();


            RuleFor(x => x.Content).MinimumLength(10);

        }
    }
}
