using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Question
{
    // GetByIdQuestionResponse.cs
    public class GetByIdQuestionResponse
    {
        public int Id { get; set; }
        public string Problem { get; set; }
        // Diğer özellikler
        public Guid ExamId { get; set; }
        public List<OptionResponse> Options { get; set; }
    }

    // OptionResponse.cs (eğer Option sınıfının özelliklerini içermek istiyorsanız)
    public class OptionResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        // Diğer özellikler
    }

}
