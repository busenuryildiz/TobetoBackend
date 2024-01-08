using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.UserUniversity
{
    public class CreatedUserUniversityResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int UniversityId { get; set; }
    }
}
