using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.CourseSubject;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseSubjectsController : ControllerBase
    {
        private ICourseSubjectService _courseSubjectService;
        private IMapper _mapper;
        public CourseSubjectsController(ICourseSubjectService courseSubjectService, IMapper mapper)
        {
            _courseSubjectService = courseSubjectService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCourseSubjectRequest createCourseSubjectRequest)
        {
            var result = await _courseSubjectService.Add(createCourseSubjectRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCourseSubjectRequest deleteCourseSubjectRequest)
        {
            var result = await _courseSubjectService.Delete(deleteCourseSubjectRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseSubjectRequest updateCourseSubjectRequest)
        {
            var result = await _courseSubjectService.Update(updateCourseSubjectRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseSubjectService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _courseSubjectService.GetById(id);
            return Ok(result);
        }
    }
}
