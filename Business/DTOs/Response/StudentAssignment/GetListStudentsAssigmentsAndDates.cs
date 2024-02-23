using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.StudentAssignment
{
    public class GetListStudentsAssigmentsAndDates
    {
        public int AssignmentId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime AssignmentAddDate { get; set; }
    }

}
