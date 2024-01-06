using Business.DTOs.Request.Application;
using FluentValidation;

namespace Business.Rules.ValidationRules;

public class CreateApplicationRequestValidator : AbstractValidator<CreateApplicationRequest>
{
    public CreateApplicationRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(600);

    }
}