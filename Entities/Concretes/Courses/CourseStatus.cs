using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class CourseStatus : Entity<int>
    {
        //tamamlanan devam eden eğitimler
        public int StudentCourseId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; }
        public StudentCourse StudentCourse { get; set; }
        
    }
}
