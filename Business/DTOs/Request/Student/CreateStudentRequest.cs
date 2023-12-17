using Entities.Concrete.Client;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Student
{
    public class CreateStudentRequest
    {

        public int StudentNumber { get; set; }
        public int CourseId { get; set; }
        
    }
}
