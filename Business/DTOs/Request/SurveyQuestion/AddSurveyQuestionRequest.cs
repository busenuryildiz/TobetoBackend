namespace Business.DTOs.Request.SurveyQuestion
{
    public class AddSurveyQuestionRequest
    {
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
    }
}
