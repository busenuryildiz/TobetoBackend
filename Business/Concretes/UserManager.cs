using AutoMapper;
using Azure.Core;
using Business.Abstracts;
using Business.DTOs.Request.Address;
using Business.DTOs.Request.City;
using Business.DTOs.Request.Country;
using Business.DTOs.Request.District;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes.Clients;
using Entities.Concretes.Profiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IStudentService _studentService;
        IMapper _mapper;
        //UserBusinessRules _userBusinessRules;
        IAddressService _addressService;
        IDistrictService _districtService;
        ICityService _cityService;
        ICountryService _countryService;

        public UserManager(IUserDal userDal, IMapper mapper, IStudentService studentService, ICountryService countryService, ICityService cityService, IDistrictService districtService, IAddressService addressService)
        {
            //_userBusinessRules = userBusinessRules;
            _userDal = userDal;
            _mapper = mapper;
            _studentService = studentService;
            _countryService = countryService;
            _cityService = cityService;
            _districtService = districtService;
            _addressService = addressService;
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
        public async Task<UpdatedUserAllInformationResponse> UpdateAllInformationAsync(UpdateUserAllInformationRequest request)
        {

            var user = await _userDal.GetAsync(u => u.Id == request.UserId,
                              include: query => query
                                .Include(u => u.Addresses)
                                  .ThenInclude(a => a.District)
                                    .ThenInclude(d => d.City)
                                      .ThenInclude(c => c.Country));
            var userAddress = user.Addresses.FirstOrDefault(p => p.UserId == request.UserId);
            if (userAddress == null)
            {
                userAddress = new Address
                {
                    UserId = request.UserId,
                    Name = request.AddressName,
                    Description = request.Description,
                    CreatedDate = DateTime.Now,
                    District = new District
                    {
                        Name = request.DistrictName,
                        CreatedDate = DateTime.Now,
                        City = new City
                        {
                            Name = request.CityName,
                            CreatedDate = DateTime.Now,
                            Country = new Country
                            {
                                Name = request.CountryName,
                                CreatedDate = DateTime.Now
                            }
                        }
                    }
                };
                user.Addresses.Add(userAddress);
            }
            else

            {
                userAddress.Name = request.AddressName;
                userAddress.UpdatedDate = DateTime.Now;
                userAddress.Description = request.Description;
                userAddress.District.Name = request.DistrictName;
                userAddress.District.UpdatedDate = DateTime.Now;
                userAddress.District.City.Name = request.CityName;
                userAddress.District.City.UpdatedDate = DateTime.Now;
                userAddress.District.City.Country.Name = request.CountryName;
                userAddress.District.City.Country.UpdatedDate = DateTime.Now;

            }
            _mapper.Map(request, user);
            await _userDal.UpdateAsync(user);
            var updatedUserResponse = _mapper.Map<UpdatedUserAllInformationResponse>(user);
            return updatedUserResponse;
        }
        public async Task<UpdatedUserAllInformationResponse> GetAllUserInformationByIdAsync(Guid id)
        {
            var user = await _userDal.GetAsync(u => u.Id == id,
                                                include: query => query
                                                    .Include(u => u.Addresses)
                                                        .ThenInclude(a => a.District)
                                                            .ThenInclude(d => d.City)
                                                                .ThenInclude(c => c.Country));

            var result = _mapper.Map<UpdatedUserAllInformationResponse>(user);
            return result;
        }

        public async Task<IPaginate<GetUsersExperienceAndEducationResponse>> GetUserExperienceAndEducationByUserId(Guid userId, int value)
        {
            var userExperiencesAndEducations = await _userDal.GetListAsync(u => u.Id == userId,
                                                                    include: query => query
                                                                    .Include(u => u.EducationInformations)
                                                                    .Include(u => u.UserExperiences),
                                                                    size: value);
            var results = _mapper.Map<Paginate<GetUsersExperienceAndEducationResponse>>(userExperiencesAndEducations);

            return results;
        }

        public async Task<UpdateChangePasswordResponse> UpdateChangePassword(UpdateChangePasswordRequest updateChangePasswordRequest)
        {
            var user = await _userDal.GetAsync(i => i.Id == updateChangePasswordRequest.UserId);
            user.Password = updateChangePasswordRequest.ChangePassword;
            user.UpdatedDate = DateTime.UtcNow;
            await _userDal.UpdateAsync(user);
            var mappedUser = _mapper.Map<UpdateChangePasswordResponse>(user);
            return mappedUser;
        }
    }

}


