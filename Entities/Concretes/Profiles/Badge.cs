using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Profiles
{
    public class Badge:Entity<int>
    {
        public string Name { get; set; }
        public string BadgePath { get; set; }
        public List<BadgeOfUser> BadgeOfUsers { get; set; }
    }
}
