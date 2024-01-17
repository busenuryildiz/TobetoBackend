using Business.DTOs.Request.User;

namespace Business.DTOs.Request.Manager;

public class UpdateManagerRequest
{
    public Guid Id { get; set; }
    public int ManagerCode { get; set; }
    public bool IsActive { get; set; }
}