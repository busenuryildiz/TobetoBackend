using Core.DataAccess.Paging;

namespace Business.DTOs.Request.SurveyAnswer
{

        public class GetListSurveyAnswerRequest : PageRequest
        {
            public int SurveyID { get; set; }
            public Guid UserID { get; set; }
            // Ekstra filtreleme veya parametreler ekleyebilirsiniz, eğer gerekirse
        }
    
}
