using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentLesson
{
    public class CreateStudentLessonRequest
    {
        public int? LessonId { get; set; }
        public Guid? StudentId { get; set; }
        public bool? IsLiked { get; set; }
        public int? Progress { get; set; }
    }

}
