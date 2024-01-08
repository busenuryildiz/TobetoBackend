using Business.DTOs.Request.Category;
using FluentValidation;

namespace Business.Rules.ValidationRules;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        
    }
}