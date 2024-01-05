namespace Business.DTOs.Response.UserUniversity;

public class DeletedUserUniversityResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int UniversityId { get; set; }
}