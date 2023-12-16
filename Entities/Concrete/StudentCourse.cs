using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class StudentCourse : Entity<int>
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Progress { get; set; }
        public string? CertificatePath { get; set; }
        public float Point { get; set; }
        public int Liked { get; set; }
        public int Saved { get; set; }
        public TimeSpan SpentTime { get; set; }
        public TimeSpan EstimatedTime { get; set; }

    }
}
