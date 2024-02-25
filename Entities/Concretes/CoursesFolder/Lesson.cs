using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.CoursesFolder
{
    public class Lesson : Entity<int>
    {
        public int? CourseId { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
        public int? CoursePartId { get; set; } 
        public DateTime? LessonDuration { get; set; }
        public string? Speaker { get; set; }
        public string? AboutSpeaker { get; set; }
        public Course? Course { get; set; }
        public CoursePart? CoursePart { get; set; }     

    }

}
