using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.UserRole;
using Business.DTOs.Response.UserRole;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class UserRoleManager:IUserRoleService
    {
        IUserRoleDal _userRoleDal;
        IMapper _mapper;
        UserRoleBusinessRules _businessRules;

        public UserRoleManager(UserRoleBusinessRules businessRules, IUserRoleDal userRoleDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserRoleResponse> Add(CreateUserRoleRequest createUserRoleRequest)
        {
            UserRole userRole = _mapper.Map<UserRole>(createUserRoleRequest);
            UserRole createdUserRole = await _userRoleDal.AddAsync(userRole);
            CreatedUserRoleResponse createdUserRoleResponse = _mapper.Map<CreatedUserRoleResponse>(createdUserRole);
            return createdUserRoleResponse;
        }

        public async Task<DeletedUserRoleResponse> Delete(DeleteUserRoleRequest deleteUserRoleRequest)
        {
            var data = await _userRoleDal.GetAsync(i => i.Id == deleteUserRoleRequest.Id);
            _mapper.Map(deleteUserRoleRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _userRoleDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedUserRoleResponse>(result);
            return result2;
        }

        public async Task<CreatedUserRoleResponse> GetById(int id)
        {
            var result = await _userRoleDal.GetAsync(c => c.Id == id);
            UserRole mappedUserRole = _mapper.Map<UserRole>(result);

            CreatedUserRoleResponse createdUserRoleResponse = _mapper.Map<CreatedUserRoleResponse>(mappedUserRole);

            return createdUserRoleResponse;
        }


        public async Task<IPaginate<GetListUserRoleResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userRoleDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListUserRoleResponse>>(data);
            return result;
        }


        public async Task<UpdatedUserRoleResponse> Update(UpdateUserRoleRequest updateUserRoleRequest)
        {
            var data = await _userRoleDal.GetAsync(i => i.Id == updateUserRoleRequest.Id);
            _mapper.Map(updateUserRoleRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _userRoleDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserRoleResponse>(data);
            return result;
        }
    }
}
