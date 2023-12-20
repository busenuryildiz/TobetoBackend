using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentSkill
{
    public class CreateStudentSkillRequest
    {
        public Guid StudentId { get; set; }
        public int SkillId { get; set; }
    }
}
