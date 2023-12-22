using Business.Abstracts;
using Business.DTOs.Request.CourseStatus;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseStatusesController : ControllerBase
    {
        ICourseStatusService _courseStatusService;
        public CourseStatusesController(ICourseStatusService courseStatusService)
        {
            _courseStatusService = courseStatusService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseStatusRequest createCourseStatusRequest)
        {
            var result = await _courseStatusService.Add(createCourseStatusRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseStatusRequest deleteCourseStatusRequest)
        {
            var result = await _courseStatusService.Delete(deleteCourseStatusRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseStatusRequest updateCourseStatusRequest)
        {
            var result = await _courseStatusService.Update(updateCourseStatusRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseStatusService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _courseStatusService.GetById(id);
            return Ok(result);
        }
    }
}
