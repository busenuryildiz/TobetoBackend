using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.UserRole;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        IUserRoleService _userRoleService;
        private IMapper _mapper;

        public UserRolesController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserRoleRequest createUserRoleRequest)
        {
            var result = await _userRoleService.Add(createUserRoleRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserRoleRequest deleteUserRoleRequest)
        {
            var result = await _userRoleService.Delete(deleteUserRoleRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRoleRequest updateUserRoleRequest)
        {
            var result = await _userRoleService.Update(updateUserRoleRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userRoleService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _userRoleService.GetRolesByUserId(id);
            return Ok(result);
        }
    }
}
