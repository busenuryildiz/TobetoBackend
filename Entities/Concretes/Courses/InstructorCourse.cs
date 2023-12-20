using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.Courses
{
    public class InstructorCourse : Entity<int>
    {
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}
