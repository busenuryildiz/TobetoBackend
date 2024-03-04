using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.StudentCourse
{
    public class DeletedStudentCourseResponse
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
