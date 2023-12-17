using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Client
{
    public class Instructor : Entity<int>
    {
        public Guid UserId { get; set; }
        public DateTime? HireDate { get; set; }
        public User User { get; set; }

    }
}
