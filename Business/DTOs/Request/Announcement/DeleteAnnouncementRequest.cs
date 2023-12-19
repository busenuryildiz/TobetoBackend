namespace Business.DTOs.Request.Announcement;

public class DeleteAnnouncementRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}