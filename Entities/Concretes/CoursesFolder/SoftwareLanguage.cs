using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.CoursesFolder
{
    public class SoftwareLanguage : Entity<int>
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }

}
