using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Address
{
    public class UpdateAddressRequest
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? CountyId { get; set; }
        public string? Name { get; set; }
        public string? AboutMe { get; set; }
    }
}
