using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.StudentCourse
{
    public class GeneralStudentCourseList
    {
        public int? CourseId { get; set; }
        public int? StudentCourseId { get; set; }
        public string? CourseName { get; set; }
        public DateTime? CourseDate { get; set; }
        public string? CourseImagePath { get; set; }
        public int? StudentCourseProgress { get; set; }
    }

}
