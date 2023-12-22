using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;

namespace Business.DTOs.Response.StudentAssignment
{
    public class GetListStudentAssignmentResponse : BasePageableModel
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Guid StudentId { get; set; }
    }
}
