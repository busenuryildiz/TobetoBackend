using Core.DataAccess.Paging;

namespace Business.DTOs.Response.ApplicationStudent;

public class UpdatedApplicationStudentResponse : BasePageableModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public Guid StudentId { get; set; }
}