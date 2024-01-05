using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.UserUniversity
{
    public class CreateUserUniversityRequest
    {
        public Guid UserId { get; set; }
        public int UniversityId { get; set; }
    }
}
