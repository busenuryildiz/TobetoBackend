using Business.Abstracts;
using Business.DTOs.Request.Blog;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateBlogRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateBlogRequest createBlogRequest)
        {
            var result = await _blogService.Add(createBlogRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBlogRequest deleteBlogRequest)
        {
            var result = await _blogService.Delete(deleteBlogRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBlogRequest updateBlogRequest)
        {
            var result = await _blogService.Update(updateBlogRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _blogService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _blogService.GetById(id);
            return Ok(result);
        }
    }
}
