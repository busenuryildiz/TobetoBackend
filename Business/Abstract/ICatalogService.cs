using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICatalogService
    {
        Task<IPaginate<GetListCatalogResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCatalogResponse> Add(CreateCatalogRequest createCatalogRequest);
        Task<UpdatedCatalogResponse> Update(UpdateCatalogRequest updateCatalogRequest);
        Task<DeletedCatalogResponse> Delete(DeleteCatalogRequest deleteCatalogRequest);
        Task<CreatedCatalogResponse> GetById(Guid id);
    }
}
