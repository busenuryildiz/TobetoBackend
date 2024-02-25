using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Exam
{
    public class ExamResultDto
    {
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public int Unanswered { get; set; }
    }

}
