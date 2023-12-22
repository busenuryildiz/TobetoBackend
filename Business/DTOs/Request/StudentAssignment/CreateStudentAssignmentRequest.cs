using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentAssignment
{
    public class CreateStudentAssignmentRequest
    {
        public int AssignmentId { get; set; }
        public Guid StudentId { get; set; }
    }
}
