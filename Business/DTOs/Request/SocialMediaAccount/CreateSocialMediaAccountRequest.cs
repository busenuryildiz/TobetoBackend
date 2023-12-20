using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.SocialMediaAccount
{

    public class CreateSocialMediaAccountRequest
    {
        public Guid UserId { get; set; }
        public string SocialMedia { get; set; }
        public string SocialMediaUrl { get; set; }
    }
}
