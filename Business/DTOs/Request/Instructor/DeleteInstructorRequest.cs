using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Instructor
{
    public class DeleteInstructorRequest
    {
        public Guid Id { get; set; }
        public int CourseId { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
