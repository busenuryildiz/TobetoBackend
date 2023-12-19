using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Announcement;

public class CreatedAnnouncementResponse : BasePageableModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}