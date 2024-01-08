using Business.DTOs.Request.InstructorCourse;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateInstructorCourseRequestValidator : AbstractValidator<CreateInstructorCourseRequest>
    {
        public CreateInstructorCourseRequestValidator()
        {
            RuleFor(x => x.InstructorId).NotEmpty();


            RuleFor(x => x.CourseId).NotNull();

        }
    }
}
