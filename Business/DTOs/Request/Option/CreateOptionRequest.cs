using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.Option
{
    public class CreateOptionRequest
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }


}
