using Entities.Concretes.Courses;

namespace Business.DTOs.Request.Exam;

public class DeleteExamRequest
{
    public int  Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    
}