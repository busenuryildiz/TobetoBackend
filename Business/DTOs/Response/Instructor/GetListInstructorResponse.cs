using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Response.Course;

namespace Business.DTOs.Response.Instructor
{
    public class GetListInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
        public List<GetListCourseResponse> Courses{ get; set; }
    }
}
