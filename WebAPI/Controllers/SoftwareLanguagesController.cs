using Business.Abstracts;
using Business.DTOs.Request.SoftwareLanguage;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLanguageController : ControllerBase
    {
        private readonly ISoftwareLanguageService _softwareLanguageService;

        public SoftwareLanguageController(ISoftwareLanguageService softwareLanguageService)
        {
            _softwareLanguageService = softwareLanguageService;
        }

        [HttpPost]
        [ValidateModel(typeof(CreateSoftwareLanguageRequestValidator))]
        public async Task<IActionResult> AddSoftwareLanguage([FromBody] CreateSoftwareLanguageRequest createSoftwareLanguageRequest)
        {
            var result = await _softwareLanguageService.Add(createSoftwareLanguageRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftwareLanguage(int id)
        {
            var deleteRequest = new DeleteSoftwareLanguageRequest { Id = id };
            var result = await _softwareLanguageService.Delete(deleteRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoftwareLanguageById(int id)
        {
            var result = await _softwareLanguageService.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSoftwareLanguages([FromQuery] PageRequest pageRequest)
        {
            var result = await _softwareLanguageService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSoftwareLanguage([FromBody] UpdateSoftwareLanguageRequest updateSoftwareLanguageRequest)
        {
            var result = await _softwareLanguageService.Update(updateSoftwareLanguageRequest);
            return Ok(result);
        }
    }
}
