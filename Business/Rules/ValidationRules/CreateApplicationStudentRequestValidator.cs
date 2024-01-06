using Business.DTOs.Request.ApplicationStudent;
using FluentValidation;

namespace Business.Rules.ValidationRules;

public class CreateApplicationStudentRequestValidator : AbstractValidator<CreateApplicationStudentRequest>
{
    public CreateApplicationStudentRequestValidator()
    {
        RuleFor(x => x.ApplicationId).NotEmpty();
        RuleFor(x => x.StudentId).NotEmpty();

    }
}