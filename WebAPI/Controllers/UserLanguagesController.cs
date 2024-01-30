using Business.Abstracts;
using Business.DTOs.Request.UserLanguage;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        IUserLanguageService _userLanguageService;
        public UserLanguagesController(IUserLanguageService userLanguageService)
        {
            _userLanguageService = userLanguageService;
        }
        [HttpPost("Add")]
        [ValidateModel(typeof(CreateUserLanguageRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateUserLanguageRequest createUserLanguageRequest)
        {
            var result = await _userLanguageService.Add(createUserLanguageRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserLanguageRequest deleteUserLanguageRequest)
        {
            var result = await _userLanguageService.Delete(deleteUserLanguageRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserLanguageRequest updateUserLanguageRequest)
        {
            var result = await _userLanguageService.Update(updateUserLanguageRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userLanguageService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _userLanguageService.GetById(id);
            return Ok(result);
        }
    }
}
