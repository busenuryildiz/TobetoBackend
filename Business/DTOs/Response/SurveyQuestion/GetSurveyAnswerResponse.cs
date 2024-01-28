using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.SurveyQuestion
{

    public class GetSurveyAnswerResponse
    {
        public int Id { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        // Diğer özellikler
    }
}
