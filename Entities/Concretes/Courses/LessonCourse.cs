using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class LessonCourse
    {
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Lesson Lesson { get; set; }
    }
}
