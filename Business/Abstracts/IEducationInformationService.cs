using Business.DTOs.Request.EducationInformation;
using Business.DTOs.Response.EducationInformation;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEducationInformationService
    {
        Task<IPaginate<GetListEducationInformationResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedEducationInformationResponse> Add(CreateEducationInformationRequest createEducationInformationRequest);
        Task<UpdatedEducationInformationResponse> Update(UpdateEducationInformationRequest updateEducationInformationRequest);
        Task<DeletedEducationInformationResponse> Delete(DeleteEducationInformationRequest deleteEducationInformationRequest);
        Task<CreatedEducationInformationResponse> GetById(int id);
    }
}
