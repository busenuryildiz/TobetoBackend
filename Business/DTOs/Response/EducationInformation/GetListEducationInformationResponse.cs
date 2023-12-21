using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.EducationInformation
{
    public class GetListEducationInformationResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string? Status { get; set; }
        public string? University { get; set; }
        public string? Faculty { get; set; }
        public DateTime? BeginningYear { get; set; }
        public DateTime? GraduationYear { get; set; }
        public bool? IsContinue { get; set; }
    }
}
