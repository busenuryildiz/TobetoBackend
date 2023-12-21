using Business.Abstracts;
using Business.DTOs.Request.Skill;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateSkillRequest createSkillRequest)
        {
            var result = await _skillService.Add(createSkillRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSkillRequest deleteSkillRequest)
        {
            var result = await _skillService.Delete(deleteSkillRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            var result = await _skillService.Update(updateSkillRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _skillService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _skillService.GetById(id);
            return Ok(result);
        }
    }
}
