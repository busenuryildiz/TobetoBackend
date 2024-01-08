using Business.DTOs.Request.StudentAssignment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateStudentAssignmentRequestValidator : AbstractValidator<CreateStudentAssignmentRequest>
    {
        public CreateStudentAssignmentRequestValidator()
        {
            RuleFor(x => x.AssignmentId).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();





        }
    }
}
