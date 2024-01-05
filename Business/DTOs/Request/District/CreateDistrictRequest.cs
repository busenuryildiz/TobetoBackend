using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.District
{
    public class CreateDistrictRequest
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
