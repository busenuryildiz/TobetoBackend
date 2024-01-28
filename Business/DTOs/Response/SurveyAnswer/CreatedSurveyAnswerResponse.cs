namespace Business.DTOs.Response.SurveyAnswer
{
    public class CreatedSurveyAnswerResponse
    {
        public int SurveyAnswerId { get; set; }
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }
        // Diğer özellikler eklenebilir
    }
}
