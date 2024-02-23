using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.User
{
    public class GetUsersExperienceAndEducationResponse
    {
        public List<UserExperienceResponse>? UserExperienceResponses { get; set; }
        public List<UserEducationInformationResponse>? UserEducationInformationResponses { get; set; }
    }

}
