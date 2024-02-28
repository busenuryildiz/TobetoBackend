using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.User
{
    public class UpdateChangePasswordRequest
    {
        public Guid UserId { get; set; }
        public string ChangePassword { get; set; }
    }
}
