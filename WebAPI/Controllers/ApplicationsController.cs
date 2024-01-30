using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Application;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private IApplicationService _applicationService;
        private IMapper _mapper;
        public ApplicationsController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        [ValidateModel(typeof(CreateApplicationRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateApplicationRequest createApplicationRequest)
        {
            var result = await _applicationService.Add(createApplicationRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteApplicationRequest deleteApplicationRequest)
        {
            var result = await _applicationService.Delete(deleteApplicationRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationRequest updateApplicationRequest)
        {
            var result = await _applicationService.Update(updateApplicationRequest);
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
