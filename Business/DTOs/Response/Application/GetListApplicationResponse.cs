using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Application
{
    public class GetListApplicationResponse : BasePageableModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
