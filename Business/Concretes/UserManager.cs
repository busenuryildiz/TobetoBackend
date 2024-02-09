using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore;


namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        //UserBusinessRules _userBusinessRules;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            //_userBusinessRules = userBusinessRules;
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
        {
            //await _userBusinessRules.EmailShouldBeUnique(createUserRequest.Email);
            //await _userBusinessRules.PhoneShouldBeUnique(createUserRequest.PhoneNumber);
            //await _userBusinessRules.NationalIdNumberCannotBeTheSame(createUserRequest.NationalIdentity);
            User user = _mapper.Map<User>(createUserRequest);
            User createdUser = await _userDal.AddAsync(user);
            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(createdUser);
            return createdUserResponse;
        }

        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            var data = await _userDal.GetAsync(predicate: i => i.Id == deleteUserRequest.Id);
            _mapper.Map(deleteUserRequest, data);
            var result = await _userDal.DeleteAsync(data);
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
                    .Include(u => u.Addresses),
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
            await _userDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserResponse>(data);
            return result;
        }



        public async Task<UserLoginResponse> Login(string email, string password)
        {
           
                var user = _userDal.Get(predicate: u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    return new UserLoginResponse
                    {
                        Id = user.Id,
                        FirstName = user?.FirstName,
                        LastName = user?.LastName,
                        Email = user?.Email,
                        BirthDate = user?.BirthDate,
                        PhoneNumber = user?.PhoneNumber,
                        ImagePath = user?.ImagePath,

                    };
                }
                return null;
            }
           
        }
    }
