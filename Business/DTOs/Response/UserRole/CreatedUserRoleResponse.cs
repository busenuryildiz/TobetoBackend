namespace Business.DTOs.Response.UserRole;

public class CreatedUserRoleResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int RoleId { get; set; }
}