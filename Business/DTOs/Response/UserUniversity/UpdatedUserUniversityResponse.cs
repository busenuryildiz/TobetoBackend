namespace Business.DTOs.Response.UserUniversity;

public class UpdatedUserUniversityResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int UniversityId { get; set; }
}