using Core.DataAccess.Paging;

namespace Business.DTOs.Response.User;

public class UpdatedUserResponse
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? NationalIdentity { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? ImagePath { get; set; }
    public string? PhoneNumber { get; set; }
}