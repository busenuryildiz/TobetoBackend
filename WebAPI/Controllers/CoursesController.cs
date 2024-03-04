using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Course;
using Business.DTOs.Response.Course;
using Business.Rules.ValidationRules;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Entities.Concretes;
using MediatR;
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
        private readonly IMediator _mediator;
        public CoursesController(ICourseService courseService, IMapper mapper, IMediator mediator)
        {
            _courseService = courseService;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("Add")]
        [ValidateModel(typeof(CreateCourseRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateCourseRequest createCourseRequest)
        {
            var result = await _courseService.Add(createCourseRequest);
            return Ok(result);
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

        [HttpPost("GetList/ByDynamic")]
        public async Task<ActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
        {
            GetListCourseByDynamicQuery getListCourseByDynamicQuery = new GetListCourseByDynamicQuery
            { PageRequest = pageRequest, Dynamic = dynamic };
            CourseListModel result = await _mediator.Send(getListCourseByDynamicQuery);
            return Ok(result);
        }

        [HttpGet("GetListAllCoursesAsync")]
        public async Task<IActionResult> GetListAllCoursesAsync()
        {
            var result = await _courseService.GetListAllCoursesAsync();
            return Ok(result);
        }
    }
}
