using Business.DTOs.Request.Role;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation
{
    public class CreateRoleRequestValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name cannot be empty.")
                .MinimumLength(2).WithMessage("Role name must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Role name cannot exceed 50 characters.");
        }
    }

}
