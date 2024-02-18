using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.ExamOfUser
{
    public class GetUsersExamResultInfoResponse
    {
        public string ExamTitle { get; set; }
        public string ExamDescription { get; set;}
        public double ExamResult { get; set;}
        public DateTime ExamDate { get; set; }
    }

}
