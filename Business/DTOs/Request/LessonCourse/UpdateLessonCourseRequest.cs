using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.LessonCourse
{
    public class UpdateLessonCourseRequest
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
    }
}
