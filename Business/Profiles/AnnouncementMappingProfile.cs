using AutoMapper;
using Core.DataAccess.Paging;
using Entities.Concretes.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Request.Announcement;
using Business.DTOs.Response.Announcement;
using Entities.Concretes;

namespace Business.Profiles
{
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<CreateAnnouncementRequest, Announcement>().ReverseMap();
            CreateMap<Announcement, CreatedAnnouncementResponse>().ReverseMap();

            CreateMap<DeleteAnnouncementRequest, Announcement>().ReverseMap();
            CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();

            CreateMap<UpdateAnnouncementRequest, Announcement>().ReverseMap();
            CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();

            CreateMap<Announcement, GetListAnnouncementResponse>().ReverseMap();
            CreateMap<IPaginate<Announcement>, IPaginate<GetListAnnouncementResponse>>().ReverseMap();
        }
    }
}
