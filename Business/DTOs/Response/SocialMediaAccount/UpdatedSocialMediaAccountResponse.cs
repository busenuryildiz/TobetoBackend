using Core.DataAccess.Paging;

namespace Business.DTOs.Response.SocialMediaAccount;

public class UpdatedSocialMediaAccountResponse : BasePageableModel
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string SocialMedia { get; set; }
    public string SocialMediaUrl { get; set; }
}