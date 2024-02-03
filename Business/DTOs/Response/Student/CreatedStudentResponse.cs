using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Response.Student
{
    public class CreatedStudentResponse 
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string StudentNumber { get; set; }
    }
}
