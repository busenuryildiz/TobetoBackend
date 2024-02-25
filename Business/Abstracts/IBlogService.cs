using Business.DTOs.Request.Blog;
using Business.DTOs.Response.Blog;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBlogService
    {
        Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedBlogResponse> Add(CreateBlogRequest createBlogRequest);
        Task<UpdatedBlogResponse> Update(UpdateBlogRequest updateBlogRequest);
        Task<DeletedBlogResponse> Delete(DeleteBlogRequest deleteBlogRequest);
        Task<CreatedBlogResponse> GetById(int id);
        Task<List<GetListBlogResponse>> GetAllBlogs();

    }
}
