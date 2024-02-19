using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.User
{
    public class UserExperienceResponse
    {
        public string? EstablishmentName { get; set; }
        public string? Position { get; set; }
        public DateTime? WorkBeginDate { get; set; }
        public DateTime? WorkEndDate { get; set; }
    }

}
