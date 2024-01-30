namespace Business.DTOs.Response.SurveyAnswer
{
    public class GetSurveyAnswerResponse
    {
        public int Id { get; set; }
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }
        public string SurveyQuestionText { get; set; }
        public string SurveyQuestionType { get; set; }
        // Diğer özellikler eklenebilir
    }

}
