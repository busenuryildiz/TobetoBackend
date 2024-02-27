using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Lesson
{
    public class GetListCourseAndLessonInfoResponse
    {
        public string? CourseName { get; set; }
        public string? CourseClassroom { get; set; }
        public DateTime? LessonDateAndHour { get; set; }
        public List<InstructorFirstAndLastName>? InstructorFirstAndLastNames { get; set; }
    }

}
