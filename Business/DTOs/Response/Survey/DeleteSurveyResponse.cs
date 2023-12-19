namespace Business.DTOs.Response.Survey
{
    public class DeleteSurveyResponse
    {
        public bool IsDeleted { get; set; }
        public Guid DeletedSurveyId { get; set; }
    }

}
