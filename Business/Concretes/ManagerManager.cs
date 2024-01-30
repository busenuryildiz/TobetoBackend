using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Manager;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Manager;
using Business.DTOs.Response.User;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;

namespace Business.Concretes
{
    public class ManagerManager : IManagerService
    {
        IManagerDal _managerDal;
        IMapper _mapper;
        ManagerBusinessRules _businessRules;
        IUserService _userManager;
        IUserDal _userDal;
        public ManagerManager(ManagerBusinessRules businessRules, IManagerDal managerDal, IMapper mapper, IUserService userManager, IUserDal userDal)
        {
            _businessRules = businessRules;
            _managerDal = managerDal;
            _userDal = userDal;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreatedManagerResponse> Add(CreateManagerRequest createManagerRequest)
        {
            Manager manager = _mapper.Map<Manager>(createManagerRequest);
            CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(createManagerRequest);
            CreatedUserResponse createdUserResponse = await _userManager.Add(createUserRequest);
            if (createdUserResponse != null)
            {
                manager.UserId = createdUserResponse.Id;
                Manager createdManager = await _managerDal.AddAsync(manager);
                CreatedManagerResponse createdManagerResponse = _mapper.Map<CreatedManagerResponse>(createdManager);
                return createdManagerResponse;
            }
            return null;
        }

        public async Task<DeletedManagerResponse> Delete(DeleteManagerRequest deleteManagerRequest)
        {
            var manager = await _managerDal.GetAsync(i => i.Id == deleteManagerRequest.Id);
            if (manager != null)
            {
                var user = await _userDal.GetAsync(u => u.Id == manager.UserId);

                if (user != null)
                {
                    try
                    {
                        await _userDal.DeleteAsync(user);
                        await _managerDal.DeleteAsync(manager);

                        var deletedManagerResponse = _mapper.Map<DeletedManagerResponse>(manager);
                        return deletedManagerResponse;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
               return null;
            }
        }

        public async Task<CreatedManagerResponse> GetById(Guid id)
        {
            var result = await _managerDal.GetAsync(c => c.Id == id);
            Manager mappedManager = _mapper.Map<Manager>(result);
            CreatedManagerResponse createdManagerResponse = _mapper.Map<CreatedManagerResponse>(mappedManager);
            return createdManagerResponse;
        }

        public async Task<IPaginate<GetListManagerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _managerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListManagerResponse>>(data);
            return result;
        }
        public async Task<UpdatedManagerResponse> Update(UpdateManagerRequest updateManagerRequest)
        {
            var data = await _managerDal.GetAsync(i => i.Id == updateManagerRequest.Id);
            _mapper.Map(updateManagerRequest, data);
            await _managerDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedManagerResponse>(data);
            return result;
        }
    }
}
