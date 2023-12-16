using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course : Entity<int>
    {
        public int CourseLevelId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Exam> Exams { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public CourseStatus CourseStatus{ get; set; }
        public CourseSubject CourseSubject{ get; set; }
        
    }
}
