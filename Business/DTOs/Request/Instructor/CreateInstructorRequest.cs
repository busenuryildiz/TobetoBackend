using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Instructor
{
    public class CreateInstructorRequest
    {
        public Guid UserId { get; set; }
        
        public DateTime? HireDate { get; set; }
    }
}
