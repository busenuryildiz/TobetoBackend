using Entities.Concrete.Client;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request
{
    public class CreateStudentRequest
    {
        public Guid UserId { get; set; }
        public int StudentNumber { get; set; }
        public int CourseId { get; set; }
       
        
    }
}
