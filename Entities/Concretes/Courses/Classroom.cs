using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class Classroom:Entity<int>
    {
        public string Name { get; set; }
        public List<ClassroomOfCourse> ClassroomOfCourses { get; set; }
    }
}
