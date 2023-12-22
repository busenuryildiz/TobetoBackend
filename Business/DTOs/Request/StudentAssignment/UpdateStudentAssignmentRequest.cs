namespace Business.DTOs.Request.StudentAssignment;

public class UpdateStudentAssignmentRequest
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public Guid StudentId { get; set; }
}