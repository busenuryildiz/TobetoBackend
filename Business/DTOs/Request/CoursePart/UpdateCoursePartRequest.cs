namespace Business.DTOs.Request.CoursePart
{
    public class UpdateCoursePartRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
    }
}
