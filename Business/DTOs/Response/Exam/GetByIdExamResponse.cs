using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;

namespace Business.DTOs.Response.Exam
{
    public class GetByIdExamResponse
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Point { get; set; }
        public TimeSpan ExamDuration { get; set; }
        public List<Question>? Questions { get; set; }
        // Include any additional fields you want to return in the response
    }
}
