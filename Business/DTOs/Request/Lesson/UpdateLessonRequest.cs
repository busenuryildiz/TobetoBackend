using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Lesson
{
    public class UpdateLessonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public DateTime LessonTime { get; set; }

    }
}
