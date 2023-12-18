using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;
using Entities.Concretes.Profiles;

namespace Entities.Concretes
{
    public class StudentSkill:Entity<int>
    {
        public Guid StudentId { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public Student Student { get; set; }

    }
}
