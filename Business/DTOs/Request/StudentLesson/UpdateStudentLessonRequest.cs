using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentLesson
{
    public class UpdateStudentLessonRequest
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public Guid? StudentId { get; set; }
        public bool? IsLiked { get; set; }
        public int? Progress { get; set; }
    }

}
