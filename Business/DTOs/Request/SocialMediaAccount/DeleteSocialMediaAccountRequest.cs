namespace Business.DTOs.Request.SocialMediaAccount;

public class DeleteSocialMediaAccountRequest
{
    public int  Id { get; set; }
    public Guid UserId { get; set; }
    public string SocialMedia { get; set; }
    public string SocialMediaUrl { get; set; }
}