
using Business.DTOs.Response.Lesson;

namespace Business.DTOs.Response.CoursePart
{
    public class GetCoursePartByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public List<CreatedLessonResponse> Lessons { get; set; } // Dersleri içeren bir liste
    }
}
