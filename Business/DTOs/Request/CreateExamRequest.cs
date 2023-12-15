using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request
{
    public class CreateExamRequest
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ExamDuration { get; set; }
        public Question? Question { get; set; }
        public int? NumberOfQuestion { get; set; }
        public int? Point { get; set; }
    }
}
