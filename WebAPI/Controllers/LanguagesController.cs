using Business.Abstracts;
using Business.DTOs.Request.Language;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        ILanguageService _languageService;
        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateLanguageRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateLanguageRequest createLanguageRequest)
        {
            var result = await _languageService.Add(createLanguageRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageRequest deleteLanguageRequest)
        {
            var result = await _languageService.Delete(deleteLanguageRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageRequest updateLanguageRequest)
        {
            var result = await _languageService.Update(updateLanguageRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _languageService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _languageService.GetById(id);
            return Ok(result);
        }
    }
}
