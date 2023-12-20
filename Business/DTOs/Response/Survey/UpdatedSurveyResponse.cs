using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Survey
{
    public class UpdatedSurveyResponse
    {
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
        public DateTime UpdatedDate { get; set; }
    }


}
