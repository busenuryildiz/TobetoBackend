using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.SurveyAnswer
{

    public class UpdatedSurveyAnswerResponse
    {
        public int SurveyAnswerId { get; set; }
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }
    }
}
