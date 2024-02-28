using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.User
{
    public class UpdateChangePasswordResponse
    {
        public Guid UserId { get; set; }
        public string ChangePassword { get; set; }
    }
}
