using Entities.Concretes;
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
        public double Point { get; set; }
        public TimeSpan? ExamDuration { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }

    }

    public class CreateQuestionDto
    {
        public string Problem { get; set; }
        public List<CreateOptionDto> Options { get; set; }
    }

    public class CreateOptionDto
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }

}
