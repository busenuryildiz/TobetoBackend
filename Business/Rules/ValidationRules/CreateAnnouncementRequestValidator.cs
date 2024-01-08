
using Business.DTOs.Request.Announcement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules
{
    public class CreateAnnouncementRequestValidator : AbstractValidator<CreateAnnouncementRequest>
    {
        public CreateAnnouncementRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();


            RuleFor(x => x.Description).MinimumLength(15);

        }
    }
}
