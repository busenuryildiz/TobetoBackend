using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.ExamOfUser
{
    public class CreatedExamOfUserResponse
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public Guid UserId { get; set; }
    }
}
