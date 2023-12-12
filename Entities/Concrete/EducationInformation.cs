using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EducationInformation
    {
        public string Status { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public DateTime BeginningYear { get; set; }
        public DateTime? GraduationYear { get; set; }

    }
}
