using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.InstructorCourse
{
    public class DeleteInstructorCourseRequest
    {
        public int Id { get; set; }
        public Guid InstructorId { get; set; }
        public int CourseId { get; set; }
    }
}
