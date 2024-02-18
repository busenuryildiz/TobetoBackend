using AutoMapper;
using Business.DTOs.Request.Student;
using Business.DTOs.Request.User;
using Business.DTOs.Response.Student;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            //// CreateStudentRequest => Student
            //CreateMap<CreateStudentRequest, Student>()
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.StudentNumber, opt => opt.Ignore()) // Bu alan GenerateStudentNumber() yöntemi tarafından doldurulacak
            //    .ForMember(dest => dest.Surveys, opt => opt.Ignore())
            //    .ForMember(dest => dest.StudentCourses, opt => opt.Ignore())
            //    .ForMember(dest => dest.StudentSkills, opt => opt.Ignore())
            //    .AfterMap((src, dest) => dest.GenerateStudentNumber()); // Öğrenci numarasını oluştur

            //// CreateStudentRequest => CreateUserRequest
            //CreateMap<CreateStudentRequest, CreateUserRequest>()
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            //    .ForMember(dest => dest.NationalIdentity, opt => opt.MapFrom(src => src.NationalIdentity))
            //    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

            //// Student => CreatedStudentResponse
            //CreateMap<Student, CreatedStudentResponse>()
            //    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            //    .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.StudentNumber))
            //    .ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.StudentCourses.FirstOrDefault().CourseId)) // Örnek olarak, ilk kursun Id'sini alıyoruz, gerektiğine göre düzenleyebilirsiniz
            //    .ForMember(dest => dest.Surveys, opt => opt.MapFrom(src => src.Surveys));

            //// CreateUserRequest => CreatedUserResponse
            //CreateMap<CreateUserRequest, CreatedUserResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id, kullanıcı oluşturulduktan sonra doldurulacak
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
            //--------------------Created---------------------------------------

            CreateMap<CreateStudentRequest, Student>().ReverseMap();
            CreateMap<CreateStudentRequest, CreateUserRequest>().ReverseMap();
            CreateMap<Student, CreatedStudentResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteStudentRequest, Student>().ReverseMap();
            CreateMap<DeleteStudentRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<Student, DeletedStudentResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateStudentRequest, Student>().ReverseMap();
            CreateMap<UpdateStudentRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<Student, GetListStudentResponse>().ReverseMap();
            CreateMap<Paginate<Student>, Paginate<GetListStudentResponse>>().ReverseMap();


            CreateMap<Student, GetStudentSkillsResponse>()
               .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.StudentSkills.Select(skill => skill.Skill.Name).ToList()))
               .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.StudentNumber, opt => opt.MapFrom(src => src.StudentNumber))
               .ReverseMap();


        }
    }
}