using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.BadgeOfUser
{
    public class CreateBadgeOfUserRequest
    {
        public int UserId { get; set; }
        public int BadgeId { get; set; }
    }
}
