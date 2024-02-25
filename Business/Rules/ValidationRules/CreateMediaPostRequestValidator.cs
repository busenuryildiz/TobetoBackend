using Business.DTOs.Request.MediaPost;
using FluentValidation;

namespace Business.Rules.ValidationRules;

public class CreateMediaPostRequestValidator : AbstractValidator<CreateMediaPostRequest>
{
    public CreateMediaPostRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();

    }
}