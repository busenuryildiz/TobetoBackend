using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Response.ApplicationStudent;
using Business.DTOs.Response.StudentAssignment;
using Business.DTOs.Response.StudentCourse;

namespace Business.DTOs.Response.Student
{
    public class GetListStudentResponse : BasePageableModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int StudentNumber { get; set; }
        public int CourseId { get; set; }
        public List<GetListApplicationStudentResponse> ApplicationStudents { get; set; }
        public List<GetListStudentAssignmentResponse> StudentAssignments { get; set; }
        public List<GetListStudentCourseResponse> StudentCourses { get; set; }
    }
}
