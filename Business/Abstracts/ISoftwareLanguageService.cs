using Business.DTOs.Request.SoftwareLanguage;
using Business.DTOs.Response.SoftwareLanguage;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISoftwareLanguageService
    {
        Task<IPaginate<GetListSoftwareLanguageResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSoftwareLanguageResponse> Add(CreateSoftwareLanguageRequest createSoftwareLanguageRequest);
        Task<UpdatedSoftwareLanguageResponse> Update(UpdateSoftwareLanguageRequest updateSoftwareLanguageRequest);
        Task<DeletedSoftwareLanguageResponse> Delete(DeleteSoftwareLanguageRequest deleteSoftwareLanguageRequest);
        Task<CreatedSoftwareLanguageResponse> GetById(int id);
    }
}
