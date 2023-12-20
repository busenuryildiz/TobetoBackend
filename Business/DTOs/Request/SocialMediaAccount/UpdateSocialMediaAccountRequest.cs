namespace Business.DTOs.Request.SocialMediaAccount;

public class UpdateSocialMediaAccountRequest
{
    public int  Id { get; set; }
    public Guid UserId { get; set; }
    public string SocialMedia { get; set; }
    public string SocialMediaUrl { get; set; }
}