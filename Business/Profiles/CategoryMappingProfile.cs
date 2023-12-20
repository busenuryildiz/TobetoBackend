using AutoMapper;
using Business.DTOs.Request.Category;
using Business.DTOs.Response.Category;
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
            // Request DTO to Entity
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();

            // Entity to Response DTO
            CreateMap<Category, CreatedCategoryResponse>();
            CreateMap<Category, DeletedCategoryResponse>();
            CreateMap<Category, UpdatedCategoryResponse>();
            CreateMap<Category, GetByIdCategoryResponse>();
            CreateMap<Category, GetListCategoryInfoResponse>();
        }
    }
}
