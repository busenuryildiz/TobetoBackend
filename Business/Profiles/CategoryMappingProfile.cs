using AutoMapper;
using Business.DTOs.Request.Category;
using Business.DTOs.Request.Category;
using Business.DTOs.Response.Category;
using Business.DTOs.Response.Category;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, CreatedCategoryResponse>().ReverseMap();

            CreateMap<DeleteCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, DeletedCategoryResponse>().ReverseMap();

            CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
            CreateMap<Category, UpdatedCategoryResponse>().ReverseMap();

            CreateMap<Category, GetListCategoryInfoResponse>().ReverseMap();
            CreateMap<Paginate<Category>, Paginate<GetListCategoryInfoResponse>>().ReverseMap();
        }
    }
}
