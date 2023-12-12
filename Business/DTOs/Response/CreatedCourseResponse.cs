using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response
{
    public class CreatedCourseResponse
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
    }
}
