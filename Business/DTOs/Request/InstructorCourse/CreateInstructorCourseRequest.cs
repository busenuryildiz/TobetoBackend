using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.InstructorCourse
{
    public class CreateInstructorCourseRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
