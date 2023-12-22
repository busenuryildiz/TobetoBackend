using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.ApplicationStudent;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStudentsController : ControllerBase
    {
        private IApplicationStudentService _applicationService;
        private IMapper _mapper;
        public ApplicationStudentsController(IApplicationStudentService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateApplicationStudentRequest createApplicationStudentRequest)
        {
            var result = await _applicationService.Add(createApplicationStudentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteApplicationStudentRequest deleteApplicationStudentRequest)
        {
            var result = await _applicationService.Delete(deleteApplicationStudentRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationStudentRequest updateApplicationStudentRequest)
        {
            var result = await _applicationService.Update(updateApplicationStudentRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _applicationService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _applicationService.GetById(id);
            return Ok(result);
        }
    }
}
