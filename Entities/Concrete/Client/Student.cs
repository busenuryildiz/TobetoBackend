using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concrete.CourseFolder;

namespace Entities.Concrete.Client
{
    public class Student : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public int StudentNumber { get; set; }
        public User User { get; set; }
        public List<Survey> Surveys { get; set; }
        public List<StudentCourse> StudentCourses { get; set; } // Eklenen alan
        public List<StudentSkill> StudentSkills { get; set; }

        public void GenerateStudentNumber()
        {
            // Öğrenci numarası oluşturma işlemleri
            StudentNumber = new Random().Next(1000, 99999);
        }
    }
}
