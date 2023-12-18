//using Business.Abstracts;
//using Business.DTOs.Request.MediaPost;
//using Core.DataAccess.Paging;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MediaPostsController : ControllerBase
//    {
//        IMediaPostService _newService;
//        public MediaPostsController(IMediaPostService newService)
//        {
//            _newService = newService;
//        }
//        [HttpPost("AddMediaPost")]
//        public async Task<IActionResult> Add([FromBody] CreateMediaPostRequest createMediaPostRequest)
//        {
//            var result = await _newService.Add(createMediaPostRequest);
//            return Ok(result);
//        }

//        [HttpPost("DeleteMediaPost")]
//        public async Task<IActionResult> Delete([FromBody] DeleteMediaPostRequest deleteMediaPostRequest)
//        {
//            var result = await _newService.Delete(deleteMediaPostRequest);
//            return Ok(result);
//        }
//        [HttpPost("UpdateMediaPost")]
//        public async Task<IActionResult> Update([FromBody] UpdateMediaPostRequest updateMediaPostRequest)
//        {
//            var result = await _newService.Update(updateMediaPostRequest);
//            return Ok(result);
//        }

//        [HttpGet("GetListMediaPost")]
//        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
//        {
//            var result = await _newService.GetListAsync(pageRequest);
//            return Ok(result);
//        }
//    }
//}
