using Business.Abstracts;
using Business.DTOs.Request.EducationInformation;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationInformationsController : ControllerBase
    {
        IEducationInformationService _educationInformationService;
        public EducationInformationsController(IEducationInformationService educationInformationService)
        {
            _educationInformationService = educationInformationService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateEducationInformationRequest createEducationInformationRequest)
        {
            var result = await _educationInformationService.Add(createEducationInformationRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteEducationInformationRequest deleteEducationInformationRequest)
        {
            var result = await _educationInformationService.Delete(deleteEducationInformationRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEducationInformationRequest updateEducationInformationRequest)
        {
            var result = await _educationInformationService.Update(updateEducationInformationRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _educationInformationService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _educationInformationService.GetById(id);
            return Ok(result);
        }
    }
}
