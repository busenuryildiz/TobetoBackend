using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.CourseSubject
{
    public class UpdateCourseSubjectRequest
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int CourseId { get; set; }
    }
}
