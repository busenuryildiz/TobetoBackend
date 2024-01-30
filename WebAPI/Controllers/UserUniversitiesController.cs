using Business.Abstracts;
using Business.Concretes;
using Business.DTOs.Request.UserUniversity;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserUniversitiesController : ControllerBase
    {
        IUserUniversityService _userUniversityService;
        public UserUniversitiesController(IUserUniversityService userUniversityService)
        {
            _userUniversityService = userUniversityService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateUserUniversityRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateUserUniversityRequest createUserUniversityRequest)
        {
            var result = await _userUniversityService.Add(createUserUniversityRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserUniversityRequest deleteUserUniversityRequest)
        {
            var result = await _userUniversityService.Delete(deleteUserUniversityRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserUniversityRequest updateUserUniversityRequest)
        {
            var result = await _userUniversityService.Update(updateUserUniversityRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userUniversityService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _userUniversityService.GetById(id);
            return Ok(result);
        }
    }
}