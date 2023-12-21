using Business.Abstracts;
using Business.DTOs.Request.InstructorCourse;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InstructorCourseController : ControllerBase
    {
        IInstructorCourseService _skillService;
        public InstructorCourseController(IInstructorCourseService skillService)
        {
            _skillService = skillService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateInstructorCourseRequest createInstructorCourseRequest)
        {
            var result = await _skillService.Add(createInstructorCourseRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteInstructorCourseRequest deleteInstructorCourseRequest)
        {
            var result = await _skillService.Delete(deleteInstructorCourseRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorCourseRequest updateInstructorCourseRequest)
        {
            var result = await _skillService.Update(updateInstructorCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _skillService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _skillService.GetById(id);
            return Ok(result);
        }
    }
}
