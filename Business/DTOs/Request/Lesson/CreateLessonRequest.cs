using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Lesson
{
    public class CreateLessonRequest
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public int CoursePartId { get; set; }
        public DateTime LessonTime { get; set; }
    }
}
