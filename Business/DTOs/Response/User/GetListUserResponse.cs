using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Response.Address;
using Entities.Concretes.Profiles;

namespace Business.DTOs.Response.User
{
    public class GetListUserResponse : BasePageableModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalIdentity { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public List<GetListAddressResponse> Addresses { get; set; }
    }
}
