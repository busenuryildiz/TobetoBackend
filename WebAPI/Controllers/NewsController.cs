using Business.Abstract;
using Business.DTOs.Request.New;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INewService _newService;
        public NewsController(INewService newService)
        {
            _newService = newService;
        }
        [HttpPost("AddNew")]
        public async Task<IActionResult> Add([FromBody] CreateNewRequest createNewRequest)
        {
            var result = await _newService.Add(createNewRequest);
            return Ok(result);
        }

        [HttpPost("DeleteNew")]
        public async Task<IActionResult> Delete([FromBody] DeleteNewRequest deleteNewRequest)
        {
            var result = await _newService.Delete(deleteNewRequest);
            return Ok(result);
        }
        [HttpPost("UpdateNew")]
        public async Task<IActionResult> Update([FromBody] UpdateNewRequest updateNewRequest)
        {
            var result = await _newService.Update(updateNewRequest);
            return Ok(result);
        }

        [HttpGet("GetListNew")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _newService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
