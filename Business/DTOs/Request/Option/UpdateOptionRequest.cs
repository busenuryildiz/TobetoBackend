namespace Business.DTOs.Request.Option
{
    public class UpdateOptionRequest
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }

}
