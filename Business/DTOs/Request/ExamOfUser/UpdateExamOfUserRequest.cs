using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.ExamOfUser
{
    public class UpdateExamOfUserRequest
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Guid UserId { get; set; }
    }
}
