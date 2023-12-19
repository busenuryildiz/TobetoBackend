using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Instructor
{
    public class DeletedInstructorResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int CourseId { get; set; }
    }
}
