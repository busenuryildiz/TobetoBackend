using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.County;
using Business.DTOs.Response.County;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class CountyManager : ICountyService
    {
        ICountyDal _countyDal;
        IMapper _mapper;
        CountyBusinessRules _businessRules;

        public CountyManager(CountyBusinessRules businessRules, ICountyDal countyDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _countyDal = countyDal;
            _mapper = mapper;
        }

        public async Task<CreatedCountyResponse> Add(CreateCountyRequest createCountyRequest)
        {
            County county = _mapper.Map<County>(createCountyRequest);
            County createdCounty = await _countyDal.AddAsync(county);
            CreatedCountyResponse createdCountyResponse = _mapper.Map<CreatedCountyResponse>(createdCounty);
            return createdCountyResponse;
        }

        public async Task<DeletedCountyResponse> Delete(DeleteCountyRequest deleteCountyRequest)
        {
            var data = await _countyDal.GetAsync(i => i.Id == deleteCountyRequest.Id);
            _mapper.Map(deleteCountyRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _countyDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCountyResponse>(result);
            return result2;
        }

        public async Task<CreatedCountyResponse> GetById(int id)
        {
            var result = await _countyDal.GetAsync(c => c.Id == id);
            County mappedCounty = _mapper.Map<County>(result);
            CreatedCountyResponse createdCountyResponse = _mapper.Map<CreatedCountyResponse>(mappedCounty);
            return createdCountyResponse;
        }


        public async Task<IPaginate<GetListCountyResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _countyDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCountyResponse>>(data);
            return result;
        }


        public async Task<UpdatedCountyResponse> Update(UpdateCountyRequest updateCountyRequest)
        {
            var data = await _countyDal.GetAsync(i => i.Id == updateCountyRequest.Id);
            _mapper.Map(updateCountyRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _countyDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCountyResponse>(data);
            return result;
        }
    }
}
