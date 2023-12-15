using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class StudentCourse:Entity<int>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
