using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Exam
{
    public class UserAnswerDto
    {
        public int QuestionId { get; set; }
        public int? SelectedOptionId { get; set; } // Kullanıcı cevap vermediyse null olabilir.
    }

}
