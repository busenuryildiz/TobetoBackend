using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.SurveyAnswer
{

    public class UpdatedSurveyAnswerResponse
    {
        // Güncellenmiş bilgiler veya başka bir duruma uygun özellikler eklenebilir
        public int SurveyAnswerId { get; set; }
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }
        // Diğer güncellenmiş özellikler eklenebilir
    }
}
