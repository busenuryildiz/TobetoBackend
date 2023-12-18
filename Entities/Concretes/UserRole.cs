using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes
{
    public class UserRole:Entity<int>
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; } // Eklenen alan
        public Role Role { get; set; } // Eklenen alan

    }
}
