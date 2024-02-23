using Business.Abstracts;
using Business.DTOs.Request.StudentLesson;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentLessonsController : ControllerBase
    {
        IStudentLessonService _studentLessonService;
        public StudentLessonsController(IStudentLessonService studentLessonService)
        {
            _studentLessonService = studentLessonService;
        }

        [HttpPost("Add")]
        //[ValidateModel(typeof(CreateStudentLessonRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateStudentLessonRequest createStudentLessonRequest)
        {
            var result = await _studentLessonService.Add(createStudentLessonRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteStudentLessonRequest deleteStudentLessonRequest)
        {
            var result = await _studentLessonService.Delete(deleteStudentLessonRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentLessonRequest updateStudentLessonRequest)
        {
            var result = await _studentLessonService.Update(updateStudentLessonRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentLessonService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _studentLessonService.GetById(id);
            return Ok(result);
        }
    }
}
