using Core.DataAccess.Paging;

namespace Business.DTOs.Response.StudentAssignment;

public class CreatedStudentAssignmentResponse : BasePageableModel
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public Guid StudentId { get; set; }
}