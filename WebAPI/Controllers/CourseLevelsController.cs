using Business.Abstracts;
using Business.DTOs.Request.CourseLevel;
using Business.DTOs.Request.CourseLevel;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseLevelsController : ControllerBase
    {
        ICourseLevelService _CourseLevelService;
        public CourseLevelsController(ICourseLevelService CourseLevelService)
        {
            _CourseLevelService = CourseLevelService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseLevelRequest createCourseLevelRequest)
        {
            var result = await _CourseLevelService.Add(createCourseLevelRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseLevelRequest deleteCourseLevelRequest)
        {
            var result = await _CourseLevelService.Delete(deleteCourseLevelRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseLevelRequest updateCourseLevelRequest)
        {
            var result = await _CourseLevelService.Update(updateCourseLevelRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _CourseLevelService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _CourseLevelService.GetById(id);
            return Ok(result);
        }
    }

}
