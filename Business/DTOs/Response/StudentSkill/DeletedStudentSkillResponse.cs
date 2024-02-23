using Core.DataAccess.Paging;

namespace Business.DTOs.Response.StudentSkill;

public class DeletedStudentSkillResponse : BasePageableModel
{
    public int  Id { get; set; }
}