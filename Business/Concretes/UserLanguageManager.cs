using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.UserLanguage;
using Business.DTOs.Response.UserLanguage;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Profiles;

namespace Business.Concretes
{
    public class UserLanguageManager : IUserLanguageService
    {

        IUserLanguageDal _userLanguageDal;
        IMapper _mapper;
        UserLanguageBusinessRules _businessRules;
        public UserLanguageManager(IUserLanguageDal userLanguageDal, IMapper mapper, UserLanguageBusinessRules businessRules)
        {
            _userLanguageDal = userLanguageDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedUserLanguageResponse> Add(CreateUserLanguageRequest createUserLanguageRequest)
        {
            UserLanguage userLanguage = _mapper.Map<UserLanguage>(createUserLanguageRequest);
            UserLanguage createdUserLanguage = await _userLanguageDal.AddAsync(userLanguage);
            CreatedUserLanguageResponse createdUserLanguageResponse = _mapper.Map<CreatedUserLanguageResponse>(createdUserLanguage);
            return createdUserLanguageResponse;
        }

        public async Task<DeletedUserLanguageResponse> Delete(DeleteUserLanguageRequest deleteUserLanguageRequest)
        {
            var data = await _userLanguageDal.GetAsync(predicate:i => i.Id == deleteUserLanguageRequest.Id);
            _mapper.Map(deleteUserLanguageRequest, data);
            var result = await _userLanguageDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedUserLanguageResponse>(result);
            return result2;
        }

        public async Task<CreatedUserLanguageResponse> GetById(int id)
        {
            var result = await _userLanguageDal.GetAsync(c => c.Id == id);
            UserLanguage mappedUserLanguage = _mapper.Map<UserLanguage>(result);
            CreatedUserLanguageResponse createdUserLanguageResponse = _mapper.Map<CreatedUserLanguageResponse>(mappedUserLanguage);
            return createdUserLanguageResponse;
        }


        public async Task<IPaginate<GetListUserLanguageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userLanguageDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListUserLanguageResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserLanguageResponse> Update(UpdateUserLanguageRequest updateUserLanguageRequest)
        {
            var data = await _userLanguageDal.GetAsync(i => i.Id == updateUserLanguageRequest.Id);
            _mapper.Map(updateUserLanguageRequest, data);
            await _userLanguageDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserLanguageResponse>(data);
            return result;
        }
    }
}
