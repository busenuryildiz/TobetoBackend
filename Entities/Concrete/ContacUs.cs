using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ContacUs:Entity<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
