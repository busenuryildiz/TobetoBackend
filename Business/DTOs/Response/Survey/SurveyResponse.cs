namespace Business.DTOs.Response.Survey
{
    public class SurveyResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Diğer özellikler eklenebilir

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        // Ek özellikler eklenebilir, örneğin oluşturulma ve güncelleme tarihleri
    }

}
