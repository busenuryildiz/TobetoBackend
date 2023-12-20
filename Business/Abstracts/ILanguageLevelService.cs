using Business.DTOs.Request.LanguageLevel;
using Business.DTOs.Response.LanguageLevel;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILanguageLevelService
    {
        Task<IPaginate<GetListLanguageLevelResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedLanguageLevelResponse> Add(CreateLanguageLevelRequest createLanguageLevelRequest);
        Task<UpdatedLanguageLevelResponse> Update(UpdateLanguageLevelRequest updateLanguageLevelRequest);
        Task<DeletedLanguageLevelResponse> Delete(DeleteLanguageLevelRequest deleteLanguageLevelRequest);
        Task<CreatedLanguageLevelResponse> GetById(int id);
    }
}
