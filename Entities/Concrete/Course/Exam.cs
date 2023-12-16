using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.Course
{
    public class Exam : Entity<int>
    {
        public int CourseId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Point { get; set; }
        public TimeSpan ExamDuration { get; set; }
        public List<Question> Questions { get; set; }
        public Course Course { get; set; }
    }
}
