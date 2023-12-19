using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Exam
{
    public class UpdateExamRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
      
    }
}
