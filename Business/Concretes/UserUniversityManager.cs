using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.UserUniversity;
using Business.DTOs.Response.UserUniversity;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class UserUniversityManager:IUserUniversityService
    {
        IUserUniversityDal _UserUniversityDal;
        IMapper _mapper;
        UserUniversityBusinessRules _businessRules;

        public UserUniversityManager(UserUniversityBusinessRules businessRules, IUserUniversityDal UserUniversityDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _UserUniversityDal = UserUniversityDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserUniversityResponse> Add(CreateUserUniversityRequest createUserUniversityRequest)
        {
            UserUniversity UserUniversity = _mapper.Map<UserUniversity>(createUserUniversityRequest);
            UserUniversity createdUserUniversity = await _UserUniversityDal.AddAsync(UserUniversity);
            CreatedUserUniversityResponse createdUserUniversityResponse = _mapper.Map<CreatedUserUniversityResponse>(createdUserUniversity);
            return createdUserUniversityResponse;
        }

        public async Task<DeletedUserUniversityResponse> Delete(DeleteUserUniversityRequest deleteUserUniversityRequest)
        {
            var data = await _UserUniversityDal.GetAsync(i => i.Id == deleteUserUniversityRequest.Id);
            _mapper.Map(deleteUserUniversityRequest, data);
            var result = await _UserUniversityDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedUserUniversityResponse>(result);
            return result2;
        }

        public async Task<CreatedUserUniversityResponse> GetById(int id)
        {
            var result = await _UserUniversityDal.GetAsync(c => c.Id == id);
            UserUniversity mappedUserUniversity = _mapper.Map<UserUniversity>(result);
            CreatedUserUniversityResponse createdUserUniversityResponse = _mapper.Map<CreatedUserUniversityResponse>(mappedUserUniversity);
            return createdUserUniversityResponse;
        }


        public async Task<IPaginate<GetListUserUniversityResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _UserUniversityDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListUserUniversityResponse>>(data);
            return result;
        }
        public async Task<UpdatedUserUniversityResponse> Update(UpdateUserUniversityRequest updateUserUniversityRequest)
        {
            var data = await _UserUniversityDal.GetAsync(i => i.Id == updateUserUniversityRequest.Id);
            _mapper.Map(updateUserUniversityRequest, data);
            await _UserUniversityDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserUniversityResponse>(data);
            return result;
        }
    }
}
