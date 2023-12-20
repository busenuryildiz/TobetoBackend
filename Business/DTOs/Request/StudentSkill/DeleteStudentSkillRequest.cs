namespace Business.DTOs.Request.StudentSkill;

public class DeleteStudentSkillRequest
{
    public int Id { get; set; }
    public Guid StudentId { get; set; }
    public int SkillId { get; set; }
}