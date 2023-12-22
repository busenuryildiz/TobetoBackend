using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.County
{
    public class DeletedCountyResponse
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }
}
