using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Address;
using Entities.Concretes.Profiles;

namespace Business.DTOs.Request.User
{
    public class CreateUserRequest
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CreateUserAddressRequest Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NationalIdentity { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }

    }


}
