using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.MediaPost;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaPostsController : ControllerBase
    {
        IMediaPostService _mediapostService;
        private IMapper _mapper;

        public MediaPostsController(IMediaPostService mediapostService, IMapper mapper)
        {
            _mediapostService = mediapostService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateMediaPostRequest createMediaPostRequest)
        {
            var result = await _mediapostService.Add(createMediaPostRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteMediaPostRequest deleteMediaPostRequest)
        {
            var result = await _mediapostService.Delete(deleteMediaPostRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateMediaPostRequest updateMediaPostRequest)
        {
            var result = await _mediapostService.Update(updateMediaPostRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _mediapostService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _mediapostService.GetById(id);
            return Ok(result);
        }
    }
}
