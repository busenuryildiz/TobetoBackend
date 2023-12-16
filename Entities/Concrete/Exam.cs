using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Exam:Entity<Guid>
    {
        public int CourseId { get; set; }
        public Guid? UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public  DateTime? ExamDuration { get; set; }
        public List<Question>? Questions { get; set; }
        public int? Point { get; set; }
        public Course Course { get; set; }
    }
}
