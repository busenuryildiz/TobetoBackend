using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.CoursePart
{
    public class GetListCoursePartResponse
    {
        public List<GetCoursePartByIdResponse> CourseParts { get; set; }
    }


}
