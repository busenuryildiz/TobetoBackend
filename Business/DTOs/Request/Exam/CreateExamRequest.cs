using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Exam
{
    public class CreateExamRequest
    {
        public int? CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Point { get; set; }
        public TimeSpan ExamDuration { get; set; }
    }

}
