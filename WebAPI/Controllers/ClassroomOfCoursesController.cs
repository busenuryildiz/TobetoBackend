using Business.Abstracts;
using Business.DTOs.Request.ClassroomOfCourse;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomOfCoursesController : ControllerBase
    {
        IClassroomOfCourseService _classroomOfCoursesService;
        public ClassroomOfCoursesController(IClassroomOfCourseService classroomOfCoursesService)
        {
            _classroomOfCoursesService = classroomOfCoursesService;
        }


        [HttpPost("Add")]
        //[ValidateModel(typeof(CreateClassroomOfCourseRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateClassroomOfCourseRequest createClassroomOfCourseRequest)
        {
            var result = await _classroomOfCoursesService.Add(createClassroomOfCourseRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteClassroomOfCourseRequest deleteClassroomOfCourseRequest)
        {
            var result = await _classroomOfCoursesService.Delete(deleteClassroomOfCourseRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClassroomOfCourseRequest updateClassroomOfCourseRequest)
        {
            var result = await _classroomOfCoursesService.Update(updateClassroomOfCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _classroomOfCoursesService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _classroomOfCoursesService.GetById(id);
            return Ok(result);
        }
    }
}
