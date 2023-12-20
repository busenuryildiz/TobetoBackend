using Business.DTOs.Request.Language;
using Business.DTOs.Response.Language;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILanguageService
    {
        Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedLanguageResponse> Add(CreateLanguageRequest createLanguageRequest);
        Task<UpdatedLanguageResponse> Update(UpdateLanguageRequest updateLanguageRequest);
        Task<DeletedLanguageResponse> Delete(DeleteLanguageRequest deleteLanguageRequest);
        Task<CreatedLanguageResponse> GetById(int id);
    }
}
