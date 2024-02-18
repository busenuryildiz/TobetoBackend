using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Skill
{
    public class UpdateSkillRequest
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
