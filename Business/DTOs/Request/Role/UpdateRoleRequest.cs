using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Role
{
    public class UpdateRoleRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
