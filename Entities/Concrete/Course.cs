using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Course
    {

        public string CourseName { get; set; }
        public int CourseDateId { get; set; }
        public string ImagePath { get; set; }
        public int CourseProgress { get; set; }
        public float Point { get; set; }
        public int Like { get; set; }
        public bool Saveds { get; set; }
    }
}
