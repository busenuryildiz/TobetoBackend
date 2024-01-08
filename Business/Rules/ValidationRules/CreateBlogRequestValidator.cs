
using Business.DTOs.Request.Blog;
using Business.Messages;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
    {
        public CreateBlogRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();


            RuleFor(x => x.Description).MinimumLength(10);

        }
    }
}




