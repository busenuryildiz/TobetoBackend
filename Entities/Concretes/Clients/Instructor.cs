using Core.Entities;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Clients
{
    public class Instructor : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime? HireDate { get; set; }
        public User User { get; set; }
        public List<InstructorCourse> InstructorCourses {  get; set; } 
    }
}
