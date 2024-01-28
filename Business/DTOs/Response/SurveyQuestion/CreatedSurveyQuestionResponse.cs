namespace Business.DTOs.Response.SurveyQuestion
{
    public class CreatedSurveyQuestionResponse
    {
        public int Id { get; set; }
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
    }
}
