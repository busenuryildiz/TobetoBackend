using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.Client;

namespace Entities.Concrete.Profile
{
    public class UserLanguage : Entity<int>
    {
        public Guid UserId { get; set; }
        public int LanguageId { get; set; }
        public int LanguageLevelId { get; set; }
        public User User { get; set; }
        public Language Language { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

    }
}
