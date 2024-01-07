using Business.DTOs.Request.Skill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillRequestValidator()
        {
            
            RuleFor(skill => skill.Name)
            .NotEmpty().WithMessage("Becerinin adı boş olamaz.")
            .MaximumLength(255).WithMessage("Becerinin adı 255 karakteri geçemez.");

            


        }
    }
}
