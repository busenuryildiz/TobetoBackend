using Business.DTOs.Request.Exam;

public class StudentExamResult
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public int Unanswered { get; set; }
    // Diğer gereken alanlar...
}

public class SubmitExamResultDto
{
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public List<UserAnswerDto> Answers { get; set; }
}
public class StudentExamResultDto
{
    public int CorrectAnswers { get; set; }
    public int WrongAnswers { get; set; }
    public int Unanswered { get; set; }
}
