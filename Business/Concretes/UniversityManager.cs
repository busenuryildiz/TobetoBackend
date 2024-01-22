using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.University;
using Business.DTOs.Response.University;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class UniversityManager : IUniversityService
    {
        IUniversityDal _universityDal;
        IMapper _mapper;
        UniversityBusinessRules _businessRules;

        public UniversityManager(UniversityBusinessRules businessRules, IUniversityDal universityDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _universityDal = universityDal;
            _mapper = mapper;
        }

        public async Task<CreatedUniversityResponse> Add(CreateUniversityRequest createUniversityRequest)
        {
            University university = _mapper.Map<University>(createUniversityRequest);
            University createdUniversity = await _universityDal.AddAsync(university);
            CreatedUniversityResponse createdUniversityResponse = _mapper.Map<CreatedUniversityResponse>(createdUniversity);
            return createdUniversityResponse;
        }

        public async Task<DeletedUniversityResponse> Delete(DeleteUniversityRequest deleteUniversityRequest)
        {
            var data = await _universityDal.GetAsync(i => i.Id == deleteUniversityRequest.Id);
            _mapper.Map(deleteUniversityRequest, data);
            var result = await _universityDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedUniversityResponse>(result);
            return result2;
        }

        public async Task<CreatedUniversityResponse> GetById(int id)
        {
            var result = await _universityDal.GetAsync(c => c.Id == id);
            University mappedUniversity = _mapper.Map<University>(result);
            CreatedUniversityResponse createdUniversityResponse = _mapper.Map<CreatedUniversityResponse>(mappedUniversity);
            return createdUniversityResponse;
        }


        public async Task<IPaginate<GetListUniversityResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _universityDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListUniversityResponse>>(data);
            return result;
        }


        public async Task<UpdatedUniversityResponse> Update(UpdateUniversityRequest updateUniversityRequest)
        {
            var data = await _universityDal.GetAsync(i => i.Id == updateUniversityRequest.Id);
            _mapper.Map(updateUniversityRequest, data);
            await _universityDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUniversityResponse>(data);
            return result;
        }

    }
}
