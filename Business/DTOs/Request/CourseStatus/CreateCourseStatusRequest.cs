using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.CourseStatus
{
    public class CreateCourseStatusRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
