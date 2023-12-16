using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Profile
{
    public class UserLanguage : Entity<int>
    {
        public Guid UserId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageLevelId { get; set; }

    }
}
