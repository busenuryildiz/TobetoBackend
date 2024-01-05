using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Profiles
{
    public class University:Entity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public List<UserUniversity> UserUniversities { get; set; }

    }
}
