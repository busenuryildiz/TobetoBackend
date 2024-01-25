using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    // Lesson sınıfına ekleyin
    public class Lesson : Entity<int>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public DateTime LessonTime { get; set; }
        public List<LessonCourse> LessonCourses { get; set; }
        public List<Assignment> Assignments { get; set; }

    }

}
