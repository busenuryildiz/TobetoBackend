using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Blog;
using Business.DTOs.Response.Blog;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        IMapper _mapper;
        BlogBusinessRules _businessRules;

        public BlogManager(BlogBusinessRules businessRules, IBlogDal blogDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _blogDal = blogDal;
            _mapper = mapper;
        }

        public async Task<CreatedBlogResponse> Add(CreateBlogRequest createBlogRequest)
        {
            Blog blog = _mapper.Map<Blog>(createBlogRequest);
            Blog createdBlog = await _blogDal.AddAsync(blog);
            CreatedBlogResponse createdBlogResponse = _mapper.Map<CreatedBlogResponse>(createdBlog);
            return createdBlogResponse;
        }

        public async Task<DeletedBlogResponse> Delete(DeleteBlogRequest deleteBlogRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == deleteBlogRequest.Id);
            _mapper.Map(deleteBlogRequest, data);
            var result = await _blogDal.DeleteAsync(data);
            var result2 = _mapper.Map<DeletedBlogResponse>(result);
            return result2;
        }

        public async Task<List<GetListBlogResponse>> GetAllBlogs()
        {
            var blogs = await _blogDal.GetListAsync();

            var mappedBlogs = _mapper.Map<List<GetListBlogResponse>>(blogs);

            return mappedBlogs;
        }

        public async Task<CreatedBlogResponse> GetById(int id)
        {
            var result = await _blogDal.GetAsync(c => c.Id == id);
            Blog mappedBlog = _mapper.Map<Blog>(result);
            CreatedBlogResponse createdBlogResponse = _mapper.Map<CreatedBlogResponse>(mappedBlog);
            return createdBlogResponse;
        }


        public async Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _blogDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListBlogResponse>>(data);
            return result;
        }


        public async Task<UpdatedBlogResponse> Update(UpdateBlogRequest updateBlogRequest)
        {
            var data = await _blogDal.GetAsync(i => i.Id == updateBlogRequest.Id);
            _mapper.Map(updateBlogRequest, data);
            await _blogDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedBlogResponse>(data);
            return result;
        }
    }
}
