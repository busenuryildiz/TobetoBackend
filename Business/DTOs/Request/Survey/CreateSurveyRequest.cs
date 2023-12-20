using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Survey
{
    public class CreateSurveyRequest
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string SurveyUrl { get; set; }
    }



}
