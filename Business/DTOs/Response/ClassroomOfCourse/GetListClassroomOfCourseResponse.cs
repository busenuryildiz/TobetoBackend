using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.ClassroomOfCourse
{
    public class GetListClassroomOfCourseResponse
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int CourseId { get; set; }
    }
}

