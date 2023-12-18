using Business.DTOs.Request.MediaPost;
using Business.DTOs.Response.MediaPost;
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
    public class MediaPostMappingProfile:Profile
    {
        public MediaPostMappingProfile()
        {
            CreateMap<CreateMediaPostRequest, MediaPost>().ReverseMap();
            CreateMap<MediaPost, CreatedMediaPostResponse>().ReverseMap();

            CreateMap<DeleteMediaPostRequest, MediaPost>().ReverseMap();
            CreateMap<MediaPost, DeletedMediaPostResponse>().ReverseMap();

            CreateMap<UpdateMediaPostRequest, MediaPost>().ReverseMap();
            CreateMap<MediaPost, UpdatedMediaPostResponse>().ReverseMap();

            CreateMap<MediaPost, GetListMediaPostResponse>().ReverseMap();
            CreateMap<Paginate<MediaPost>, Paginate<GetListMediaPostResponse>>().ReverseMap();
        }
    }
}
