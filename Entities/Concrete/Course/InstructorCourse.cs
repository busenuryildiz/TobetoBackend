using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Course
{
    public class InstructorCourse : Entity<int>
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
    }
}
