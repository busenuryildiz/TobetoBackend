using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Instructor
{
    public class UpdateInstructorRequest
    {
        public Guid Id { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
