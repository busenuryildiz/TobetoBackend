using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.Profiles
{
    public class UserUniversity:Entity<int>
    {
        public Guid UserId { get; set; }
        public int UniversityId { get; set; }
        public User User { get; set; }
        public University University { get; set; }
    }
}
