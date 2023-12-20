using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.UserRole
{
    public class UpdateUserRoleRequest
    {
        public int  Id { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
    }
}
