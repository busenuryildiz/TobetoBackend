using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.ContactUs
{
    public class CreatedContactUsResponse : BasePageableModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}
