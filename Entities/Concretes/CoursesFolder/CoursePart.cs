using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes.CoursesFolder
{
    public class CoursePart : Entity<int>
    {
        public string Title { get; set; }
        public int CourseId { get; set; } // CourseId özelliği eklendi
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
