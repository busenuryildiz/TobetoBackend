namespace Business.DTOs.Request.Survey
{
    // UpdateSurveyRequest sınıfı
    public class UpdateSurveyRequest
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
    }

}
