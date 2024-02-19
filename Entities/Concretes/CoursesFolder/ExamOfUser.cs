using Core.Entities;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.CoursesFolder
{
    public class ExamOfUser:Entity<int>
    {
        public int? ExamId { get; set; }
        public Guid? UserId { get; set; }
        public double ExamResult { get; set; }
        public User? User { get; set; }
        public Exam? Exam { get; set; }
    }
}
