namespace Business.DTOs.Request.SurveyAnswer
{
   
        public class AddSurveyAnswerRequest
        {
            public Guid UserID { get; set; }
            public int SurveyID { get; set; }
            public int QuestionID { get; set; }
            public string AnswerValue { get; set; }
            // Diğer özellikler eklenebilir
        }
    
}
