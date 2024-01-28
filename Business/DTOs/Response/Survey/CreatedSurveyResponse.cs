namespace Business.DTOs.Response.Survey
{

    // CreatedSurveyResponse
    public class CreatedSurveyResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserID { get; set; }
    }



}
