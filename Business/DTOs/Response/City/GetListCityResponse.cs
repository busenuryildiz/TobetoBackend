using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Response.District;

namespace Business.DTOs.Response.City
{
    public class GetListCityResponse
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<GetListDistrictResponse> Districts { get; set; }

    }
}
