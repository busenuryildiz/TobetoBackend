using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.Profiles
{
    public class Address: Entity<int>
    {
        public Guid UserId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public string AboutMe { get; set; }
        public District District { get; set; }
        public User User { get; set; }

    }
}
