using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Survey
{
    public class GetByIdSurveyResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<GetSurveyQuestionResponse> SurveyQuestions { get; set; }
    }
}
