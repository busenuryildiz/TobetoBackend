namespace Business.DTOs.Request.University;

public class UpdateUniversityRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
}