using Business.DTOs.Request.University;
using Business.DTOs.Response.University;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUniversityService
    {
        Task<IPaginate<GetListUniversityResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedUniversityResponse> Add(CreateUniversityRequest createUniversityRequest);
        Task<UpdatedUniversityResponse> Update(UpdateUniversityRequest updateUniversityRequest);
        Task<DeletedUniversityResponse> Delete(DeleteUniversityRequest deleteUniversityRequest);
        Task<CreatedUniversityResponse> GetById(int id);
    }
}
