namespace Business.DTOs.Response.Exam
{
    public class GetListExamInfoResponse
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public TimeSpan ExamDuration { get; set; }
    }
}
