using Business.DTOs.Response.Option;

namespace Business.DTOs.Response.Question
{
    public class UpdatedQuestionResponse
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Problem { get; set; }
    }
}
