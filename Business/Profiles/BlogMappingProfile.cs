using AutoMapper;
using Business.DTOs.Request.Blog;
using Business.DTOs.Response.Blog;
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
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<CreateBlogRequest, Blog>().ReverseMap();
            CreateMap<Blog, CreatedBlogResponse>().ReverseMap();

            CreateMap<DeleteBlogRequest, Blog>().ReverseMap();
            CreateMap<Blog, DeletedBlogResponse>().ReverseMap();

            CreateMap<UpdateBlogRequest, Blog>().ReverseMap();
            CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();

            CreateMap<Blog, GetListBlogResponse>().ReverseMap();
            CreateMap<Paginate<Blog>, Paginate<GetListBlogResponse>>().ReverseMap();
        }
    }
}
