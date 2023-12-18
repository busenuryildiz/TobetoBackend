using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Profiles
{
    public class Language : Entity<int>
    {
        public string Name { get; set; }
        public int LanguageLevelId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

        public List<UserLanguage> UserLanguages { get; set; }
    }

}
