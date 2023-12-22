using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.Subject
{
    public class GetListSubjectResponse:BasePageableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
