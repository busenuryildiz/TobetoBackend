using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor:Entity<int>
    {
        public DateTime? HireDate { get; set; }
        public User User { get; set; }

    }
}
