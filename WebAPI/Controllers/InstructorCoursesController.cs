using Business.Abstracts;
using Business.DTOs.Request.InstructorCourse;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InstructorCoursesController : ControllerBase
    {
        IInstructorCourseService InstructorCourseService;
        public InstructorCoursesController(IInstructorCourseService skillService)
        {
            InstructorCourseService = skillService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateInstructorCourseRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateInstructorCourseRequest createInstructorCourseRequest)
        {
            var result = await InstructorCourseService.Add(createInstructorCourseRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteInstructorCourseRequest deleteInstructorCourseRequest)
        {
            var result = await InstructorCourseService.Delete(deleteInstructorCourseRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorCourseRequest updateInstructorCourseRequest)
        {
            var result = await InstructorCourseService.Update(updateInstructorCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await InstructorCourseService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await InstructorCourseService.GetById(id);
            return Ok(result);
        }
    }
}
