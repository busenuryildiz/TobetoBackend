using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.ApplicationStudent
{
    public class GetListApplicationStudentResponse: BasePageableModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public Guid StudentId { get; set; }
    }
}
