using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Address
{
    public class DeletedAddressResponse
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? DistrictId { get; set; }
        public string? Name { get; set; }
        public string? AboutMe { get; set; }
    }
}
