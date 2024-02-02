using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Course;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;
        private IMapper _mapper; 
        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ValidateModel(typeof(CreateCourseRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
        {
            try
            {
                var result = await _courseService.Add(createCourseRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // İç istisnayı (inner exception) konsola yazdırma
                Console.WriteLine("Inner Exception:");
                Console.WriteLine(ex.InnerException?.Message);

                // Dış istisnayı (outer exception) konsola yazdırma
                Console.WriteLine("Outer Exception:");
                Console.WriteLine(ex.Message);

                // Dönüş yaparken genel bir hata mesajı verme
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCourseRequest deleteCourseRequest)
        {
            var result = await _courseService.Delete(deleteCourseRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
        {
            var result = await _courseService.Update(updateCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _courseService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _courseService.GetById(id);
            return Ok(result);
        }
    }
}
