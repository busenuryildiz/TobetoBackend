using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.Clients
{
    public class Manager:Entity<Guid>
    {
        public Guid UserId { get; set; }
        public int ManagerCode { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
    }
}
