namespace Business.DTOs.Request.Survey
{
    // Survey Request Nesneleri
    public class CreateSurveyRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserID { get; set; }
    }

}
