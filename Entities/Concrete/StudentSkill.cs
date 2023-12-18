using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.Client;
using Entities.Concrete.Profile;

namespace Entities.Concrete
{
    public class StudentSkill:Entity<int>
    {
        public int StudentId { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public Student Student { get; set; }

    }
}
