using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Address
{
    public class CreateAddressRequest
    {
        public Guid? UserId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public string? Name { get; set; }
        public string? AboutMe { get; set; }
    }
}
