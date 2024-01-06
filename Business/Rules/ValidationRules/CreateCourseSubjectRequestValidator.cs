using Business.DTOs.Request.CourseSubject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateCourseSubjectRequestValidator : AbstractValidator<CreateCourseSubjectRequest>
    {
        public CreateCourseSubjectRequestValidator()
        {
            RuleFor(x => x.SubjectId).NotEmpty();
            RuleFor(x => x.CourseId).NotEmpty();




        }
    }
}
