using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.LessonCourse
{
    public class GetListLessonCourseResponse
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string LessonName { get; set; }
        public DateTime LessonTime { get; set; }
        public string InstructorName { get; set; }
        public string ClassroomName { get; set; }

    }
}
