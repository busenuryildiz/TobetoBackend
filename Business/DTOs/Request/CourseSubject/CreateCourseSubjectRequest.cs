using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.CourseSubject
{
    public class CreateCourseSubjectRequest
    {
        public int SubjectId { get; set; }
        public int CourseId { get; set; }
    }
}
