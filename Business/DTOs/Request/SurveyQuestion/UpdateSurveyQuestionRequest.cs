namespace Business.DTOs.Request.SurveyQuestion
{
    public class UpdateSurveyQuestionRequest
    {
        public int Id { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
    }
}
