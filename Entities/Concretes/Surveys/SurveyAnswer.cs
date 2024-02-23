using Core.Entities;
using Entities.Concretes.Clients;

namespace Entities.Concretes.Surveys
{
    public class SurveyAnswer : Entity<int>
    {
        public Guid UserID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string AnswerValue { get; set; }

        // Navigation Properties
        public virtual Survey Survey { get; set; }  // Cevabın bağlı olduğu anket
        public virtual User User { get; set; }  // Cevabı veren kullanıcı
        public virtual SurveyQuestion SurveyQuestion { get; set; }  // Cevabın bağlı olduğu soru
    }
}
