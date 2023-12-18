using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.Client;

namespace Entities.Concrete
{
    public class UserRole:Entity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User User { get; set; } // Eklenen alan
        public Role Role { get; set; } // Eklenen alan

    }
}
