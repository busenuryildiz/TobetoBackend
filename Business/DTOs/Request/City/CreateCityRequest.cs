using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.City
{
    public class CreateCityRequest
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
