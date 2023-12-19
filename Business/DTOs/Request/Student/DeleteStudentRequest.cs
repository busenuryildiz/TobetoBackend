using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Student
{
    public class DeleteStudentRequest
    {
        public Guid Id { get; set; }
        public int StudentNumber { get; set; }
        public int CourseId { get; set; }
    }
}
