using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.CoursePart
{
    public class GetListCoursePartResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public List<GetCoursePartByIdResponse> CourseParts { get; set; }
    }


}
