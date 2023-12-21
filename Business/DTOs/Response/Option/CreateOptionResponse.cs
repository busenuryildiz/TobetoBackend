using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Option
{
    public class CreatedOptionResponse
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }


}
