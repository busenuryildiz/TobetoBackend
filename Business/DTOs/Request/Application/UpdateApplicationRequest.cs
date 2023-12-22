namespace Business.DTOs.Request.Application;

public class UpdateApplicationRequest
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}