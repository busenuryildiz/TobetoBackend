//using Business.Abstracts;
//using Business.DTOs.Request.Course;
//using Core.DataAccess.Paging;
//using Entities.Concretes;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CoursesController : ControllerBase
//    {
//        private ICourseService _courseService;

//        public CoursesController(ICourseService courseService)
//        {
//            _courseService = courseService;
//        }

//        [HttpPost("Add")]
//        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
//        {
//            var result = await _courseService.Add(createCourseRequest);
//            return Ok(result);
//        }
//        [HttpPost("Delete")]
//        public async Task<IActionResult> Delete([FromBody] DeleteCourseRequest deleteCourseRequest)
//        {
//            var result = await _courseService.Delete(deleteCourseRequest);
//            return Ok(result);
//        }
//        [HttpPost("Update")]
//        public async Task<IActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
//        {
//            var result = await _courseService.Update(updateCourseRequest);
//            return Ok(result);
//        }

//        [HttpGet("GetList")]
//        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
//        {
//            var result = await _courseService.GetListAsync(pageRequest);
//            return Ok(result);
//        }
//        [HttpGet("GetById")]
//        public async Task<IActionResult> GetById([FromQuery] Guid id)
//        {
//            var result = await _courseService.GetById(id);
//            return Ok(result);
//        }
//    }
//}
