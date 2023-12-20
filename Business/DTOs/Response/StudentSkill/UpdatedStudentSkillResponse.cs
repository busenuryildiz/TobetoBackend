using Core.DataAccess.Paging;

namespace Business.DTOs.Response.StudentSkill;

public class UpdatedStudentSkillResponse : BasePageableModel
{
    public int  Id { get; set; }
    public Guid StudentId { get; set; }
    public int SkillId { get; set; }
}