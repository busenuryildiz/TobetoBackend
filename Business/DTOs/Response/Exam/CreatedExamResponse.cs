using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;

namespace Business.DTOs.Response.Exam
{
    public class CreatedExamResponse
    {
        public int Id { get; set; }
        // Include any additional fields you want to return in the response
    }
}
