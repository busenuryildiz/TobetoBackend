using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.CoursesFolder
{
    public class StudentAssignment:Entity<int>
    {
        public int AssignmentId { get; set; }
        public Guid StudentId { get; set; }
        public bool? IsSend { get; set; }
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
    }
}
