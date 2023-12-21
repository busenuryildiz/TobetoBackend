using Business.DTOs.Request.Option;

public class CreateQuestionRequest
{
    public int ExamId { get; set; }
    public string Problem { get; set; }
    public List<CreateOptionRequest> Options { get; set; }
}

