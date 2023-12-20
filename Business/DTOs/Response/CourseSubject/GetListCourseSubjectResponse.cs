using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.CourseSubject
{
    public class GetListCourseSubjectResponse : BasePageableModel
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int CourseId { get; set; }
    }
}
