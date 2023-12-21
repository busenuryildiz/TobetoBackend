using Business.DTOs.Request.Option;

namespace Business.DTOs.Request.Question
{
    public class UpdateQuestionRequest
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Problem { get; set; }
    }
}
