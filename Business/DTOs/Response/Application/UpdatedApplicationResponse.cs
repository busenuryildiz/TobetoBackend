using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Application;

public class UpdatedApplicationResponse : BasePageableModel
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}