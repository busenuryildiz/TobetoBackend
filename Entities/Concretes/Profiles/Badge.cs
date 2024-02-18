using Core.Entities;
using Entities.Concretes.CoursesFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Profiles
{
    public class Badge:Entity<int>
    {
        public string Name { get; set; }
        public string BadgePath { get; set; }
        public int CourseId { get; set; }
        public List<BadgeOfUser> BadgeOfUsers { get; set; }
        public Course Course { get; set; }
    }
}
