using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.User
{
    public class UpdatedUserAllInformationResponse
    {
        public Guid? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public string? Password { get; set; }
        public string? NationalIdentity { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? DistrictName { get; set; }
        public string? CityName { get; set; }
        public string? CountryName { get; set; }
        public string? AddressName { get; set; }
        public string? Description { get; set; }
    }
}
