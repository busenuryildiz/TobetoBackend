using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.New
{
    public class CreateNewRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? Date { get; set; }
    }
}
