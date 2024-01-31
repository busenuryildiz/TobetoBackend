using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.CoursesFolder
{
    public class StudentCourse : Entity<int>
    {
        public Guid? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? Progress { get; set; }
        public string? CertificatePath { get; set; }
        public float? Point { get; set; }
        public int? Liked { get; set; }
        public int? Saved { get; set; }
        public bool? IsPaid { get; set; }
        public TimeSpan? SpentTime { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        public Student? Student { get; set; } // Eklenen alan
        public Course? Course { get; set; } // Eklenen alan
        public List<Payment>? Payments { get; set; } // Eklenen alan


    }
}
