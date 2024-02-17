using Business.Abstracts;
using Business.DTOs.Request.Badge;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        IBadgeService _badgeService;
        public BadgesController(IBadgeService BadgeService)
        {
            _badgeService = BadgeService;
        }


        [HttpPost("Add")]

        public async Task<IActionResult> Add([FromBody] CreateBadgeRequest createBadgeRequest)
        {
            var result = await _badgeService.Add(createBadgeRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteBadgeRequest deleteBadgeRequest)
        {
            var result = await _badgeService.Delete(deleteBadgeRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBadgeRequest updateBadgeRequest)
        {
            var result = await _badgeService.Update(updateBadgeRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _badgeService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _badgeService.GetById(id);
            return Ok(result);
        }
    }
}
