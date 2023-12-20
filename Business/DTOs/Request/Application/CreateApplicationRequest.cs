using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Application
{
    public class CreateApplicationRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
