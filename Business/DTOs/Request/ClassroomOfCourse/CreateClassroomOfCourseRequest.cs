using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.ClassroomOfCourse
{
    public class CreateClassroomOfCourseRequest
    {
        public int ClassroomId { get; set; }
        public int CourseId { get; set; }
    }
}
