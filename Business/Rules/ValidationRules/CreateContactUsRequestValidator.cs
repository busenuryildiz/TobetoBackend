using Business.DTOs.Request.ContactUs;
using FluentValidation;

namespace Business.Rules.ValidationRules;

public class CreateContactUsRequestValidator : AbstractValidator<CreateContactUsRequest>
{
    public CreateContactUsRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();

        RuleFor(x => x.Message).MaximumLength(400);

    }
}