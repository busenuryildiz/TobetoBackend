using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.InstructorCourse
{
    public class CreatedInstructorCourseResponse : BasePageableModel
    {
        public int Id { get; set; }
        public Guid InstructorId { get; set; }
        public int CourseId { get; set; }
    }
}
