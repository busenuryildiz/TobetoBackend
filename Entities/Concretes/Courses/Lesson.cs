using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.Courses
{
    public class Lesson : Entity<int>
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }

        //ilgili alanlar,details clasına bakılacak.

    }
}
