using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Student
{
    public class CreateStudentRequest
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StudenNumber { get; set; }
        public string NationalIdentity { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        // Diğer özellikleri buraya ekleyebilirsiniz
    }

}
