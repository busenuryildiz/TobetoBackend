namespace Business.DTOs.Request.Application;

public class UpdateApplicationRequest
{
    public int  Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}