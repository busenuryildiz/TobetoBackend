namespace Business.DTOs.Response.UserRole;

public class CreatedUserRoleResponse
{
    public Guid UserId { get; set; }
    public List<string> Roles { get; set; }
    // Diğer gerekli alanlar
}
