using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Lesson
{
    public class CreatedLessonResponse : BasePageableModel
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
    }
}
