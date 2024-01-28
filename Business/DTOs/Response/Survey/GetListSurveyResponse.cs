namespace Business.DTOs.Response.Survey
{
    // GetListSurveyResponse
    public class GetListSurveyResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserID { get; set; }
    }



}
