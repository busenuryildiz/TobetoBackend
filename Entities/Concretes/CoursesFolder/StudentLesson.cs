using Core.Entities;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.CoursesFolder
{
    public class StudentLesson:Entity<int>
    {
        public int LessonId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsLiked { get; set; }
        public int Progress { get; set; }
        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }

}
