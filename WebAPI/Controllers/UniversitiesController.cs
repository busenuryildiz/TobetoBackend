using Business.Abstracts;
using Business.DTOs.Request.University;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        IUniversityService _universityService;
        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateUniversityRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateUniversityRequest createUniversityRequest)
        {
            var result = await _universityService.Add(createUniversityRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUniversityRequest deleteUniversityRequest)
        {
            var result = await _universityService.Delete(deleteUniversityRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUniversityRequest updateUniversityRequest)
        {
            var result = await _universityService.Update(updateUniversityRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _universityService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _universityService.GetById(id);
            return Ok(result);
        }
    }
}