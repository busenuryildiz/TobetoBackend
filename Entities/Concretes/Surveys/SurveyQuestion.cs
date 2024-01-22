using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concretes.Surveys
{
    public class SurveyQuestion : Entity<int>
    {
        public int SurveyID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }

        // Navigation Properties
        public virtual Survey Survey { get; set; }  // Sorunun bağlı olduğu anket
        public virtual ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }
}
