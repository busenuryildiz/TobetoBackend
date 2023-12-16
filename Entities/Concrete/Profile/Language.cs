using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Profile
{
    public class Language : Entity<int>
    {
        public string Name { get; set; }
        public int LanguageLevelId { get; set; }
    }
}
