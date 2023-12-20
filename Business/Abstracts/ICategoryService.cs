using Business.DTOs.Request.Category;
using Business.DTOs.Response.Category;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
        Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest);
        Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest);
        Task<GetByIdCategoryResponse> GetById(int id);
        Task<IPaginate<GetListCategoryInfoResponse>> GetListAsync(PageRequest pageRequest);
    }
}
