using Business.DTOs.Request.LessonCourse;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateLessonCourseRequestValidator : AbstractValidator<CreateLessonCourseRequest>
    {
        public CreateLessonCourseRequestValidator()
        {
            RuleFor(x => x.LessonId).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty();





        }
    }
}
