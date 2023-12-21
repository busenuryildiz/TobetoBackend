namespace Business.DTOs.Response.UserExperience
{
    public class CreatedUserExperienceResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string EstablishmentName { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string City { get; set; }
        public DateTime WorkBeginDate { get; set; }
        public DateTime WorkEndDate { get; set; }
        public string Description { get; set; }
    }
}
