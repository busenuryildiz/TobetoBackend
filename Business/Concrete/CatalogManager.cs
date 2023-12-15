using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CatalogManager: ICatalogService
    {
        ICatalogDal _catalogDal;
        IMapper _mapper;
        CatalogBusinessRules _catalogBusinessRules;

        public CatalogManager(ICatalogDal catalogDal, IMapper mapper, CatalogBusinessRules catalogBusinessRules)
        {
            _catalogDal = catalogDal;
            _mapper = mapper;
            _catalogBusinessRules = catalogBusinessRules;
        }

        public async Task<CreatedCatalogResponse> Add(CreateCatalogRequest createCatalogRequest)
        {
            var mappedRequest = _mapper.Map<Catalog>(createCatalogRequest);
            var createdRequest = await _catalogDal.AddAsync(mappedRequest);
            var createdResponse = _mapper.Map<CreatedCatalogResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<DeletedCatalogResponse> Delete(DeleteCatalogRequest deleteCatalogRequest)
        {
            var mappedRequest = _mapper.Map<Catalog>(deleteCatalogRequest);
            var createdRequest = await _catalogDal.DeleteAsync(mappedRequest);
            var createdResponse = _mapper.Map<DeletedCatalogResponse>(createdRequest);
            return createdResponse;
        }

        public async Task<CreatedCatalogResponse> GetById(Guid id)
        {
            var result = await _catalogDal.GetAsync(c => c.Id == id);
            var mappedResult = _mapper.Map<Catalog>(result);
            var createdResponse = _mapper.Map<CreatedCatalogResponse>(mappedResult);

            return createdResponse;
        }

        public async Task<IPaginate<GetListCatalogResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _catalogDal.GetListAsync();
            var result = _mapper.Map<Paginate<GetListCatalogResponse>>(data);

            return result;
        }

        public async Task<UpdatedCatalogResponse> Update(UpdateCatalogRequest updateCatalogRequest)
        {
            var mappedRequest = _mapper.Map<Catalog>(updateCatalogRequest);
            var updatedRequest = await _catalogDal.UpdateAsync(mappedRequest);
            var updatedResponse = _mapper.Map<UpdatedCatalogResponse>(updatedRequest);

            return updatedResponse;
        }
    }
}
