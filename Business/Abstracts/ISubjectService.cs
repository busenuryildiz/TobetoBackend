using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISubjectService
    {
        Task<IPaginate<SubjectResponse>> GetAllSubjectsAsync(PageRequest pageRequest);
        Task<SubjectResponse> AddSubjectAsync(CreateSubjectRequest request);
        Task<SubjectResponse> GetSubjectByIdAsync(int id);
        Task<SubjectResponse> UpdateSubjectAsync(UpdateSubjectRequest request);
        Task<bool> DeleteSubjectAsync(int id);
    }
}
