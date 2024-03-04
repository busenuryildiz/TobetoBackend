using Business.Abstracts;
using Business.DTOs.Request.Lesson;
using Business.DTOs.Response.Lesson;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateLessonRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateLessonRequest createLessonRequest)
        {
            var result = await _lessonService.Add(createLessonRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteLessonRequest deleteLessonRequest)
        {
            var result = await _lessonService.Delete(deleteLessonRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLessonRequest updateLessonRequest)
        {
            var result = await _lessonService.Update(updateLessonRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _lessonService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _lessonService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetAllCourseAndLessonInfo")]
        public async Task<IActionResult> GetAllCourseAndLessonInfo()
        {
            var result = await _lessonService.GetAllCourseAndLessonInfo();

            return Ok(result);
        }
        [HttpGet("GetListCoursesAllLessonsAsync")]
        public async Task<IActionResult> GetListCoursesAllLessonsAsync([FromQuery] int courseId)
        {
            var result = await _lessonService.GetListCoursesAllLessonsAsync(courseId);

            return Ok(result);
        }
    }
}
