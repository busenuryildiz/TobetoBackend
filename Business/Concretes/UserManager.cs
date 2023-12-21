using AutoMapper;
using Business.Abstracts;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore;


namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _userBusinessRules;

        public UserManager(UserBusinessRules userBusinessRules, IUserDal userDal, IMapper mapper)
        {
            _userBusinessRules = userBusinessRules;
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
        {
            await _userBusinessRules.EmailShouldBeUnique(createUserRequest.Email);
            await _userBusinessRules.NationalIdNumberCannotBeTheSame(createUserRequest.NationalIdentity);
            User user = _mapper.Map<User>(createUserRequest);
            User createdUser = await _userDal.AddAsync(user);
            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(createdUser);
            return createdUserResponse;
        }

        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            var data = await _userDal.GetAsync(i => i.Id == deleteUserRequest.Id);
            _mapper.Map(deleteUserRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _userDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedUserResponse>(result);
            return result2;
        }

        public async Task<CreatedUserResponse> GetById(Guid id)
        {
            var result = await _userDal.GetAsync(c => c.Id == id);
            User mappedUser = _mapper.Map<User>(result);

            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(mappedUser);

            return createdUserResponse;
        }


        public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userDal.GetListAsync(
                include: u => u
                    .Include(u => u.Student)
                    .Include(u => u.Instructor)
                    .Include(u => u.EducationInformations)
                    .Include(u => u.Certificates)
                    .Include(u => u.SocialMediaAccounts)
                    .Include(u => u.UserExperiences)
                    .Include(u => u.UserLanguages)
                    .Include(u => u.UserRoles)
                    .Include(u => u.Applications),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );

            var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
            return result;
        }


        public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
        {
            var data = await _userDal.GetAsync(i => i.Id == updateUserRequest.Id);
            _mapper.Map(updateUserRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _userDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserResponse>(data);
            return result;
        }
    }
}