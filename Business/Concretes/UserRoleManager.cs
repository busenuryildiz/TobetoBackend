using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.UserRole;
using Business.DTOs.Response.UserRole;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;



namespace Business.Concretes
{
    public class UserRoleManager:IUserRoleService
    {
        IUserRoleDal _userRoleDal;
        IMapper _mapper;

        public UserRoleManager(UserRoleBusinessRules businessRules, IUserRoleDal userRoleDal, IMapper mapper)
        {
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
            var result = await _userRoleDal.DeleteAsync(data);
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
            await _userRoleDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserRoleResponse>(data);
            return result;
        }

        public async Task<CreatedUserRoleResponse> GetRolesByUserId(Guid userId)
        {
            // Kullanıcının rollerini repository üzerinden al
            var userRoles = await _userRoleDal.GetListAsync(
                predicate: p => p.UserId == userId,
                include: q => q.Include(ur => ur.User).Include(ur => ur.Role)
            );

            // Kullanıcının rollerini listeye ekle
            var roles = new List<string>();
            foreach (var userRole in userRoles.Items)
            {
                // Assuming RoleName is a property in your Role entity
                roles.Add(userRole.Role?.Name);
            }

            // Burada CreatedUserRoleResponse oluşturabilir ve gerekli işlemleri yapabilirsiniz.
            var response = new CreatedUserRoleResponse
            {
                UserId = userId,
                Roles = roles
            };

            return response;
        }

    }
}
