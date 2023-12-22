using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Assignments
{
    public class CreateAssignmentRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CourseId { get; set; }
        public string? FilePath { get; set; }
        public DateTime DeadLine { get; set; }
        public bool? IsSend { get; set; }
    }
}
