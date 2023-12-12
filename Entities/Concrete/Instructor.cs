using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Instructor:Entity<Guid>
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }
    }
}
