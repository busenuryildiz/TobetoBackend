using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.City;
using Business.DTOs.Response.City;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CityManager : ICityService
    {
        ICityDal _CityDal;
        IMapper _mapper;
        CityBusinessRules _businessRules;

        public CityManager(CityBusinessRules businessRules, ICityDal CityDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _CityDal = CityDal;
            _mapper = mapper;
        }

        public async Task<CreatedCityResponse> Add(CreateCityRequest createCityRequest)
        {
            City City = _mapper.Map<City>(createCityRequest);
            City createdCity = await _CityDal.AddAsync(City);
            CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(createdCity);
            return createdCityResponse;
        }

        public async Task<DeletedCityResponse> Delete(DeleteCityRequest deleteCityRequest)
        {
            var data = await _CityDal.GetAsync(i => i.Id == deleteCityRequest.Id);
            _mapper.Map(deleteCityRequest, data);
            var result = await _CityDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCityResponse>(result);
            return result2;
        }

        public async Task<CreatedCityResponse> GetById(int id)
        {
            var result = await _CityDal.GetAsync(c => c.Id == id);
            City mappedCity = _mapper.Map<City>(result);
            CreatedCityResponse createdCityResponse = _mapper.Map<CreatedCityResponse>(mappedCity);
            return createdCityResponse;
        }


        public async Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _CityDal.GetListAsync(
                include: u => u
                    .Include(c => c.Districts),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCityResponse>>(data);
            return result;
        }


        public async Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest)
        {
            var data = await _CityDal.GetAsync(i => i.Id == updateCityRequest.Id);
            _mapper.Map(updateCityRequest, data);
            await _CityDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCityResponse>(data);
            return result;
        }
    }
}
