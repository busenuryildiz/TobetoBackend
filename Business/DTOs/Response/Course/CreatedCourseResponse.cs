using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Course
{
    public class CreatedCourseResponse
    {
        public int Id { get; set; }
        public int? CourseLevelId { get; set; }
        public int? SoftwareLanguageId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public double? Price { get; set; }
        public string CourseType { get; set; }
        public int? Duration { get; set; }
        public string Classroom { get; set; }
        public List<CoursePartResponse> CourseParts { get; set; } // CoursePart'ları içeren liste
    }

    public class CoursePartResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<LessonResponse> Lessons { get; set; } // Lesson'ları içeren liste
    }

    public class LessonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public DateTime LessonTime { get; set; }
    }
}

