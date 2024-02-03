namespace Business.DTOs.Request.Student;

public class UpdateStudentRequest
{
    public Guid Id { get; set; }
    public string StudentNumber { get; set; }
    public int CourseId { get; set; }
}