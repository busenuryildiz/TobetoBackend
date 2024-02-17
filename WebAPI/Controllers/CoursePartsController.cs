using Business.Abstracts;
using Business.DTOs.Request.CoursePart;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursePartController : ControllerBase
    {
        private readonly ICoursePartService _coursePartService;

        public CoursePartController(ICoursePartService coursePartService)
        {
            _coursePartService = coursePartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CreateCoursePartRequest createCoursePartRequest)
        {
            var createdCoursePart = await _coursePartService.Add(createCoursePartRequest);
            return Ok(createdCoursePart);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCoursePartRequest deleteCoursePartRequest)
        {
            var deletedCoursePart = await _coursePartService.Delete(deleteCoursePartRequest);
            return Ok(deletedCoursePart);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCoursePartRequest updateCoursePartRequest)
        {
            var updatedCoursePart = await _coursePartService.Update(updateCoursePartRequest);
            return Ok(updatedCoursePart);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coursePart = await _coursePartService.GetById(id);
            if (coursePart == null)
                return NotFound();

            return Ok(coursePart);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var paginatedCourseParts = await _coursePartService.GetListAsync(pageRequest);
            return Ok(paginatedCourseParts);
        }
    }

}
