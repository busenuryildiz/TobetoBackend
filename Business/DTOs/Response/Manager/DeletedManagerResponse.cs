using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Manager;

public class DeletedManagerResponse : BasePageableModel
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public int ManagerCode { get; set; }
    public bool IsActive { get; set; }
}