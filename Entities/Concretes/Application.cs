using Core.Entities;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Application : Entity<int>
    {
        public Guid UserId { get; set; } 
        public string Name { get; set; } 
        public bool IsActive { get; set; }
        public User User { get; set; }

    }
}
   