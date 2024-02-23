using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.Concretes.CoursesFolder
{
    public class Assignment : Entity<int>
    {

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime DeadLine { get; set; } // ödev süresinde gönderilsin.
        public Course Course { get; set; }
        public List<StudentAssignment> StudentAssignments { get; set; }

    }
}
