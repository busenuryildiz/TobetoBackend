using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.StudentSkill
{
    public class GetListStudentSkillResponse:BasePageableModel
    {
        public int  Id { get; set; }
        public Guid StudentId { get; set; }
        public int SkillId { get; set; }
    }
}
