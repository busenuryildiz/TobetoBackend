namespace Business.DTOs.Response.SurveyQuestion
{
    public class UpdatedSurveyQuestionResponse
    {
        public int Id { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
    }
}
