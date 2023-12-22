using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Subject;

public class DeletedSubjectResponse : BasePageableModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}