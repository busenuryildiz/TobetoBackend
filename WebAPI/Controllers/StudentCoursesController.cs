using Business.Abstracts;
using Business.DTOs.Request.Blog;
using Business.DTOs.Request.StudentCourse;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        IStudentCourseService _studentCourseService;

        public StudentCoursesController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateStudentCourseRequest createStudentCourseRequest)
        {
            var result = await _studentCourseService.Add(createStudentCourseRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentCourseRequest deleteStudentCourseRequest)
        {
            var result = await _studentCourseService.Delete(deleteStudentCourseRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCourseRequest updateStudentCourseRequest)
        {
            var result = await _studentCourseService.Update(updateStudentCourseRequest);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentCourseService.GetById(id);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentCourseService.GetListAsync(pageRequest);
            return Ok(result);
        }

    }
}
