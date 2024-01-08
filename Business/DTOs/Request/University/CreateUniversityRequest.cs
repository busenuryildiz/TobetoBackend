using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.University
{
    public class CreateUniversityRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
    }
}
