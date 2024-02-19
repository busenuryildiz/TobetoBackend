namespace Business.DTOs.Response.StudentCourse;

    public class GetUserBadgesResponse
    {
        public Guid UserId { get; set; }
        public int StudentCourseId { get; set; }
        public int CourseId { get; set; }
        public string BadgePath { get; set; }
    }


