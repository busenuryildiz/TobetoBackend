using Azure.Core;
using Business.Abstracts;
using Business.DTOs.Request.User;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _userService.Add(createUserRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return StatusCode(500, $"An error occurred while processing your request: {ex.InnerException.Message}");


            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserRequest deleteUserRequest)
        {
            var result = await _userService.Delete(deleteUserRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.Update(updateUserRequest);
            return Ok(result);
        }
        [HttpPut("UpdateChangePassword")]
        public async Task<IActionResult> UpdateChangePassword([FromBody] UpdateChangePasswordRequest updateChangePasswordRequest)
        {
            try
            {
                var result = await _userService.UpdateChangePassword(updateChangePasswordRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya uygun işlemleri yapabilirsiniz.
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        [HttpPut("UpdateAllUserInformation")]

        public async Task<IActionResult> Update([FromBody] UpdateUserAllInformationRequest request)
        {
            var result = await _userService.UpdateAllInformationAsync(request);
            return Ok(result);
        }

        [HttpGet("GetAllUserInformationById")]
        public async Task<IActionResult> GetAllUserInformationById([FromQuery] Guid id)
        {
            var result = await _userService.GetAllUserInformationByIdAsync(id);
            return Ok(result);
        }



        [HttpGet("GetUserExperienceAndEducationByUserId")]
        public async Task<IActionResult> GetUserExperienceAndEducationByUserId([FromQuery] Guid userId)
        {
            var result = await _userService.GetUserExperienceAndEducationByUserId(userId, int.MaxValue);

            return Ok(result);
        }
    }
}