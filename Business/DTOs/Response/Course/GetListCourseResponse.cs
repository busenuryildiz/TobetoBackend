using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Course
{
    public class GetListCourseResponse : BasePageableModel
    {
        public int Id { get; set; }
        public int? CourseLevelId { get; set; }
        public string? CourseLevelName { get; set; }
        public string? CourseSubjectName { get; set; }
        public int? SoftwareLanguageId { get; set; }
        public string? SoftwareLanguageName { get; set; }
        public string? Classroom { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? InstructorName { get; set; }
        public string? Name { get; set; }
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
        public int? Duration { get; set; }
    }
}
