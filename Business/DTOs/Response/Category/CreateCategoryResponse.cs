using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Category
{
    public class CreatedCategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Include any additional fields you want to return in the response
    }
}
