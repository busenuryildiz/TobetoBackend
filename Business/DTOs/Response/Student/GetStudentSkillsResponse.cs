using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Student
{
    public class GetStudentSkillsResponse
    {
        public Guid StudentId { get; set; }
        public string StudentNumber { get; set; }
        public List<string> SkillName { get; set; }
    }
}
