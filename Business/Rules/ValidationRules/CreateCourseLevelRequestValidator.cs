using Business.DTOs.Request.CourseLevel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateCourseLevelRequestValidator : AbstractValidator<CreateCourseLevelRequest>
    {
        public CreateCourseLevelRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();



        }
    }
}
