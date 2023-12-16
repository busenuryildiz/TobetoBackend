using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class StudentSkill:Entity<int>
    {
        public int StudentId { get; set; }
        public int SkillId { get; set; }
    }
}
