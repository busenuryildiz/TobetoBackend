using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Category;
using Business.DTOs.Response.Blog;
using Business.DTOs.Response.Category;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            Category createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

        public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            var data = await _categoryDal.GetAsync(i => i.Id == deleteCategoryRequest.Id);
            _mapper.Map(deleteCategoryRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _categoryDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCategoryResponse>(result);
            return result2;
        }

        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
        {
            var data = await _categoryDal.GetAsync(i => i.Id == updateCategoryRequest.Id);
            _mapper.Map(updateCategoryRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _categoryDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCategoryResponse>(data);
            return result;
        }


        public async Task<CreatedCategoryResponse> GetById(int id)
        {
            var result = await _categoryDal.GetAsync(c => c.Id == id);
            Category mappedCategory = _mapper.Map<Category>(result);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(mappedCategory);
            return createdCategoryResponse;
        }



        public async Task<IPaginate<GetListCategoryInfoResponse>> GetListAsync(PageRequest pageRequest)
        {
            var categories = await _categoryDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );

            // Map the categories to GetListCategoryInfoResponse
            var result = _mapper.Map<Paginate<GetListCategoryInfoResponse>>(categories);

            return result;
        }

    }
}
