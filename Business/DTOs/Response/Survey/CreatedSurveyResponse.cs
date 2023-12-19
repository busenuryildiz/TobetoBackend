namespace Business.DTOs.Response.Survey
{
    public class CreatedSurveyResponse
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }


}
