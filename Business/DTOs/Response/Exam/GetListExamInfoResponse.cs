namespace Business.DTOs.Response.Exam
{
    public class GetListExamInfoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Point { get; set; }
        public TimeSpan ExamDuration { get; set; }
    }
}
