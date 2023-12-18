using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Profile
{
    public class LanguageLevel : Entity<int>
    {
        public string Name { get; set; }

        public List<Language> Languages { get; set; }
    }

}
