using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.UserRole
{
    public class GetRolesByUserIdRequest
    {
        public Guid UserId { get; set; }
    }

}
