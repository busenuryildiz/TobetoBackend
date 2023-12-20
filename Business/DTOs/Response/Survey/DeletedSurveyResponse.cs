namespace Business.DTOs.Response.Survey
{
    public class DeletedSurveyResponse
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
        public DateTime DeletedDate { get; set; }
    }


}
