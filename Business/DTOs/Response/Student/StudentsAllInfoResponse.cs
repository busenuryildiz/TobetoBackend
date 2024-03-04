using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Student
{
    public class StudentsAllInfoResponse
    {
        public Guid UserId { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImagePath { get; set; }
    }

}
