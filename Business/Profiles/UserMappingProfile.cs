using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Business.DTOs.Request.LessonCourse;
using Business.DTOs.Response.LessonCourse;
using Entities.Concretes.CoursesFolder;
using System.Runtime.InteropServices;
using Business.DTOs.Response.UserLanguage;
using Entities.Concretes.Profiles;

namespace Business.Profiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<DeleteUserRequest, User>().ReverseMap();
            CreateMap<User, DeletedUserResponse>().ReverseMap();

            CreateMap<UpdateUserRequest, User>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();

            CreateMap<User, GetListUserResponse>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses));
            //CreateMap<Paginate<User>, Paginate<GetListUserResponse>>().ReverseMap();
            CreateMap<Paginate<User>, Paginate<GetListUserResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)).ReverseMap();



            CreateMap<User, UpdatedUserAllInformationResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AddressName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().Description))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.City.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.City.Country.Name))
            .ReverseMap();

            CreateMap<User, UpdateUserAllInformationRequest>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AddressName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().Description))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.Name))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.City.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Addresses.FirstOrDefault().District.City.Country.Name))
            .ReverseMap();

            CreateMap<User, GetUsersExperienceAndEducationResponse>()
               .ForMember(dest => dest.UserEducationInformationResponse, opt => opt.MapFrom(src => src.EducationInformations))
               .ForMember(dest => dest.UserExperienceResponse, opt => opt.MapFrom(src => src.UserExperiences));

            CreateMap<Paginate<User>, Paginate<GetUsersExperienceAndEducationResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<EducationInformation, UserEducationInformationResponse>();
            CreateMap<UserExperience, UserExperienceResponse>();




        }
    }
}
