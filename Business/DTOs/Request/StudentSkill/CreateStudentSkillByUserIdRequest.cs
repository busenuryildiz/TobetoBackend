using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentSkill
{
    public class CreateStudentSkillByUserIdRequest
    {
        public Guid UserId { get; set; }
        public int SkillId { get; set; }
    }
}
