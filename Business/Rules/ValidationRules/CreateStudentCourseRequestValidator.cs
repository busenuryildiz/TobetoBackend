using Business.DTOs.Request.StudentCourse;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateStudentCourseRequestValidator : AbstractValidator<CreateStudentCourseRequest>
    {
        public CreateStudentCourseRequestValidator()
        {
            RuleFor(x => x.Progress).NotEmpty();


            RuleFor(x => x.Point).InclusiveBetween(1, 100);

        }
    }
}
