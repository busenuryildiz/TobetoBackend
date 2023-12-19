using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Manager
{
    public class CreatedManagerResponse
    {
        public int Id { get; set; }
        public Guid ManagerId { get; set; }
        public int ManagerCode { get; set; }
        public bool IsActive { get; set; }
    }
}
