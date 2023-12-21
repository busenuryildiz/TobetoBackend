namespace Business.DTOs.Response.Option
{
    public class GetListOptionResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }

}
