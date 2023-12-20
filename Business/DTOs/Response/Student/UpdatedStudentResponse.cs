using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Student
{
    public class UpdatedStudentResponse : BasePageableModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int StudentNumber { get; set; }
        public int CourseId { get; set; }
    }
}
