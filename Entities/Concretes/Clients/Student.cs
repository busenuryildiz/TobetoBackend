using Core.Entities;
using Entities.Concretes.CoursesFolder;
using Entities.Concretes.Surveys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Concretes.Clients
{
    public class Student : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string StudentNumber { get; set; }
        public User? User { get; set; }
        public virtual ICollection<Survey> AssignedSurveys { get; set; } = new List<Survey>();  // Öğrenciye atanmış anketler
        public List<StudentCourse>? StudentCourses { get; set; } // Eklenen alan
        public List<StudentSkill>? StudentSkills { get; set; }
        public List<ApplicationStudent>? ApplicationStudents { get; set; }
        public List<StudentAssignment>? StudentAssignments { get; set; }
        
    }
}
