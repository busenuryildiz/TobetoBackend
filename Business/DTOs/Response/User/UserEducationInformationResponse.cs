using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.User
{
    public class UserEducationInformationResponse
    {
        public string? University { get; set; }
        public string? Faculty { get; set; }
        public DateTime? BeginningYear { get; set; }
        public DateTime? GraduationYear { get; set; }
    }

}
