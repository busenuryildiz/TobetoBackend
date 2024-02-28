using Business.DTOs.Response.Lesson;
using Business.DTOs.Response.StudentLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.StudentCourse
{
    public class CoursesAllLessonInfoResponse
    {
        public int? CourseId { get; set; }
        public int? StudentCourseId { get; set; }
        public Guid? StudentId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseImagePath { get; set; }
        public float? Point { get; set; }
        public string? AreasOfInterest { get; set; }
        public bool? StudentCourseIsLiked { get; set; }
        public bool? StudentCourseIsSaved { get; set; }
        public int? StudentCourseProgress { get; set; }
        public string? CourseProducerCompany { get; set; }
        public string? CourseCategoryNames { get; set; }
        public DateTime? StudentCourseStartDate { get; set; }
        public TimeSpan? StudentCourseSpentTime { get; set; }
        public TimeSpan? StudentCourseEstimatedTime { get; set; }
        public List<GetListLessonResponse>? GetListLessonResponses { get; set; }
        public List<GetListStudentLessonResponse>? GetListStudentLessonResponses { get; set; }
    }

}
