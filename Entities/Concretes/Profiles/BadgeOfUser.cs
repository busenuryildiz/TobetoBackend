using Core.Entities;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Profiles
{
    public class BadgeOfUser:Entity<int>
    {
        public Guid UserId { get; set; }
        public int BadgeId { get; set; }
        public Badge Badge { get; set; }
        public User User { get; set; }

    }
}
