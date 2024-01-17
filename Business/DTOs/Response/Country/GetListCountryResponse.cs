using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Response.City;

namespace Business.DTOs.Response.Country
{
    public class GetListCountryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetListCityResponse> Cities { get; set; }

    }
}
