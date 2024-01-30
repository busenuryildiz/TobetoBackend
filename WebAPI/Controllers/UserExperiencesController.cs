using Business.Abstracts;
using Business.DTOs.Request.UserExperience;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExperiencesController : ControllerBase
    {
        IUserExperienceService _userExperienceService;
        public UserExperiencesController(IUserExperienceService userExperienceService)
        {
            _userExperienceService = userExperienceService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateUserExperienceRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateUserExperienceRequest createUserExperienceRequest)
        {
            var result = await _userExperienceService.Add(createUserExperienceRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserExperienceRequest deleteUserExperienceRequest)
        {
            var result = await _userExperienceService.Delete(deleteUserExperienceRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserExperienceRequest updateUserExperienceRequest)
        {
            var result = await _userExperienceService.Update(updateUserExperienceRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userExperienceService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _userExperienceService.GetById(id);
            return Ok(result);
        }

    }
}
