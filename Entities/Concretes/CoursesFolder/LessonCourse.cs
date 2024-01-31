using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.CoursesFolder
{
    public class LessonCourse: Entity<int>
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Lesson Lesson { get; set; }
      
    }
}
