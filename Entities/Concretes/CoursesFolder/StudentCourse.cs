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
        public int? Liked { get; set; }
        public int? Saved { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? SpentTime { get; set; }
        public int? EstimatedTime { get; set; }
        public Student? Student { get; set; } 
        public Course? Course { get; set; } 
        public List<Payment>? Payments { get; set; } 


    }
}
