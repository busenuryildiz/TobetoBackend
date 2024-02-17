using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.BadgeOfUser
{
    public class GetListBadgeOfUserResponse
    {
        public int Id { get; set; }
        public int BadgeId { get; set; }
        public int UserId { get; set; }
    }
}
