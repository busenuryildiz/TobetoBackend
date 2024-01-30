using Business.Abstracts;
using Business.DTOs.Request.Announcement;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementService _announcementService;
        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateAnnouncementRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateAnnouncementRequest createAnnouncementRequest)
        {
            var result = await _announcementService.Add(createAnnouncementRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteAnnouncementRequest deleteAnnouncementRequest)
        {
            var result = await _announcementService.Delete(deleteAnnouncementRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            var result = await _announcementService.Update(updateAnnouncementRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _announcementService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _announcementService.GetById(id);
            return Ok(result);
        }
    }
}
