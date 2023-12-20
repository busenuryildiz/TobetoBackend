namespace Business.DTOs.Request.UserRole;

public class CreateUserRoleRequest
{
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
}