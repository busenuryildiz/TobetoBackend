using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentCourse
{
    public class UpdateStudentCourseRequest
    {
        public int Id { get; set; }
        public Guid? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? Progress { get; set; }
        public string? CertificatePath { get; set; }
        public int? Liked { get; set; }
        public int? Saved { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? IsCompleted { get; set; }
        public TimeSpan? SpentTime { get; set; }
        public TimeSpan? EstimatedTime { get; set; }

    }
}
