using Business.DTOs.Response.Lesson;

namespace Business.DTOs.Response.CoursePart
{
    public class GetCoursePartByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CreatedLessonResponse> Lessons { get; set; }

        // Diğer döndürülecek özellikler eklenebilir
    }
}
