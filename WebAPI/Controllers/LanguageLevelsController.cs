using Business.Abstracts;
using Business.DTOs.Request.LanguageLevel;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageLevelsController : ControllerBase
    {
        ILanguageLevelService _languageLevelService;
        public LanguageLevelsController(ILanguageLevelService languageLevelService)
        {
            _languageLevelService = languageLevelService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateLanguageLevelRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateLanguageLevelRequest createLanguageLevelRequest)
        {
            var result = await _languageLevelService.Add(createLanguageLevelRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageLevelRequest deleteLanguageLevelRequest)
        {
            var result = await _languageLevelService.Delete(deleteLanguageLevelRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageLevelRequest updateLanguageLevelRequest)
        {
            var result = await _languageLevelService.Update(updateLanguageLevelRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _languageLevelService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _languageLevelService.GetById(id);
            return Ok(result);
        }
    }
}
