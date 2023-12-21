using Business.DTOs.Response.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Question
{
    public class CreatedQuestionResponse
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Problem { get; set; }
        public List<CreatedOptionResponse> Options { get; set; }
    }

}
