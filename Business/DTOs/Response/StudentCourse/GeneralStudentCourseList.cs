using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.StudentCourse
{
    public class GeneralStudentCourseList
    {
        public int StudentCourseId { get; set; }
        public string StudentCourseName { get; set; }
        public DateTime StudentCourseDate { get; set; }
        public string StudentCourseImagePath { get; set; }
        public int StudentCourseProgress { get; set; }
    }

}
