using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class ClassroomOfCourse:Entity<int>
    {
        public int CourseId { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public Course Course { get; set; }
    }
}
