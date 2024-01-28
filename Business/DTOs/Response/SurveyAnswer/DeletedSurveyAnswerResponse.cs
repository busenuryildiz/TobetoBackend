namespace Business.DTOs.Response.SurveyAnswer
{
    public class DeletedSurveyAnswerResponse
    {
        // Silinen öğeye dair bilgiler veya başka bir duruma uygun özellikler eklenebilir
        public int SurveyAnswerId { get; set; }
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }
        // Diğer silinen özellikler eklenebilir
    }
}
