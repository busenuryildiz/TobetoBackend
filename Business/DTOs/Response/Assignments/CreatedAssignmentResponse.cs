using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;

namespace Business.DTOs.Response.Assignments
{
    public class CreatedAssignmentResponse : BasePageableModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int LessonId { get; set; }
        public string? FilePath { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool? IsSend { get; set; }
    }
}
