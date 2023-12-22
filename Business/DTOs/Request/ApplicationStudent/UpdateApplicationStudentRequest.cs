namespace Business.DTOs.Request.ApplicationStudent;

public class UpdateApplicationStudentRequest
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public Guid StudentId { get; set; }
}