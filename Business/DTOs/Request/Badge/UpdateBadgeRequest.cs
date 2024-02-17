using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Badge
{
    public class UpdateBadgeRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BadgePath { get; set; }
    }
}
