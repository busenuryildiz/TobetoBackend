using Business.Abstracts;
using Business.DTOs.Request.UserExperience;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExperienceController : ControllerBase
    {
        private readonly IUserExperienceService _userExperienceService;

        public UserExperienceController(IUserExperienceService userExperienceService)
        {
            _userExperienceService = userExperienceService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userExperienceService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserExperienceRequest createUserExperienceRequest)
        {
            var result = await _userExperienceService.Add(createUserExperienceRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserExperienceRequest updateUserExperienceRequest)
        {
            var result = await _userExperienceService.Update(updateUserExperienceRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserExperienceRequest deleteUserExperienceRequest)
        {
            var result = await _userExperienceService.Delete(deleteUserExperienceRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userExperienceService.GetById(id);
            return Ok(result);
        }

        [HttpGet("byUserId/{userId}")]
        public async Task<IActionResult> GetUserExperiencesByUserId(Guid userId)
        {
            var result = await _userExperienceService.GetUserExperiencesByUserId(userId);
            return Ok(result);
        }
    }
}
