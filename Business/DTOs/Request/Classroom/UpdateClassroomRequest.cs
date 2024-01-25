using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Classroom
{
    public class UpdateClassroomRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
