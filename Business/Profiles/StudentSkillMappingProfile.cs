﻿using Business.DTOs.Request.StudentSkill;
using Business.DTOs.Request.User;
using Business.DTOs.Response.StudentSkill;
using Business.DTOs.Response.User;
using Core.DataAccess.Paging;
using Entities.Concretes.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concretes;

namespace Business.Profiles
{
    public class StudentSkillMappingProfile:Profile
    {
        public StudentSkillMappingProfile()
        {
            //--------------------Created---------------------------------------

            CreateMap<CreateStudentSkillRequest, StudentSkill>().ReverseMap();
            CreateMap<CreateStudentSkillRequest, CreateUserRequest>().ReverseMap();
            CreateMap<StudentSkill, CreatedStudentSkillResponse>().ReverseMap();
            CreateMap<CreateUserRequest, CreatedUserResponse>().ReverseMap();


            //-------------------Deleted----------------------------------------------

            CreateMap<DeleteStudentSkillRequest, StudentSkill>().ReverseMap();
            CreateMap<DeleteStudentSkillRequest, DeleteUserRequest>().ReverseMap();
            CreateMap<StudentSkill, DeletedStudentSkillResponse>().ReverseMap();
            CreateMap<DeleteUserRequest, DeletedUserResponse>().ReverseMap();

            //-------------------Updated---------------------------------------------
            CreateMap<UpdateStudentSkillRequest, StudentSkill>().ReverseMap();
            CreateMap<UpdateStudentSkillRequest, UpdateUserRequest>().ReverseMap();
            CreateMap<StudentSkill, UpdatedStudentSkillResponse>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdatedUserResponse>().ReverseMap();

            //--------------------Listeleme-----------------------------------

            CreateMap<StudentSkill, GetListStudentSkillResponse>().ReverseMap();
            CreateMap<Paginate<StudentSkill>, Paginate<GetListStudentSkillResponse>>().ReverseMap();
        }
    }
}
