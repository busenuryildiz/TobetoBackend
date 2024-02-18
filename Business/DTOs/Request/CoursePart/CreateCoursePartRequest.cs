using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.CoursePart
{
    public class CreateCoursePartRequest
    {
        public string Title { get; set; }
        public int CourseId { get; set; }
    }

}
