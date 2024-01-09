using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.District;
using Business.DTOs.Response.District;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _districtDal;
        IMapper _mapper;
        DistrictBusinessRules _businessRules;

        public DistrictManager(DistrictBusinessRules businessRules, IDistrictDal districtDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _districtDal = districtDal;
            _mapper = mapper;
        }

        public async Task<CreatedDistrictResponse> Add(CreateDistrictRequest createDistrictRequest)
        {
            District district = _mapper.Map<District>(createDistrictRequest);
            District createdDistrict = await _districtDal.AddAsync(district);
            CreatedDistrictResponse createdDistrictResponse = _mapper.Map<CreatedDistrictResponse>(createdDistrict);
            return createdDistrictResponse;
        }

        public async Task<DeletedDistrictResponse> Delete(DeleteDistrictRequest deleteDistrictRequest)
        {
            var data = await _districtDal.GetAsync(predicate:i => i.Id == deleteDistrictRequest.Id);
            _mapper.Map(deleteDistrictRequest, data);
            var result = await _districtDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedDistrictResponse>(result);
            return result2;
        }

        public async Task<CreatedDistrictResponse> GetById(int id)
        {
            var result = await _districtDal.GetAsync(c => c.Id == id);
            District mappedDistrict = _mapper.Map<District>(result);
            CreatedDistrictResponse createdDistrictResponse = _mapper.Map<CreatedDistrictResponse>(mappedDistrict);
            return createdDistrictResponse;
        }


        public async Task<IPaginate<GetListDistrictResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _districtDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListDistrictResponse>>(data);
            return result;
        }


        public async Task<UpdatedDistrictResponse> Update(UpdateDistrictRequest updateDistrictRequest)
        {
            var data = await _districtDal.GetAsync(i => i.Id == updateDistrictRequest.Id);
            _mapper.Map(updateDistrictRequest, data);
            await _districtDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedDistrictResponse>(data);
            return result;
        }
    }
}
