using Core.DataAccess.Paging;

namespace Business.DTOs.Response.User;

public class DeletedUserResponse : BasePageableModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Address { get; set; }
    public string Email { get; set; }
    public string? NationalIdentity { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }

}