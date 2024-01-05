namespace Business.DTOs.Request.UserUniversity;

public class UpdateUserUniversityRequest
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int UniversityId { get; set; }
}