using Core.Entities;
using Entities.Concretes.Clients;
using System.Collections.Generic;

namespace Entities.Concretes.Surveys
{
    public class Survey : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatorUserID { get; set; }


        // Navigation Properties
        public virtual User User { get; set; }  // Anketi oluşturan kullanıcı
        public virtual Student Student { get; set; }  // Ankete atanmış öğrenci
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }
}
