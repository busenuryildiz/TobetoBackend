using Business.DTOs.Response.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Question
{
    public class GetListQuestionResponse
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        public List<GetOptionResponse> Options { get; set; }
    }

    public class GetOptionResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; } // Gerçek bir uygulamada, bu alanın sınav esnasında gizli tutulması gerekebilir.
    }

}
