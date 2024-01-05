using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Request.StudentCourse
{
    public class UpdateStudentCourseRequest
    {
        public int Id { get; set; }
        public int? Progress { get; set; }
        // Güncellenecek özellikleri buraya ekleyebilirsiniz
    }
}
