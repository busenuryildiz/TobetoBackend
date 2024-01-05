using Business.Abstracts;
using Business.DTOs.Request.Role;
using Core.Aspects.ActionFilters;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogActionFilter))] // Action Filter'ı ekleyin

    public class RolesController : ControllerBase
    {
        IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateRoleRequest createRoleRequest)
        {
            var result = await _roleService.Add(createRoleRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteRoleRequest deleteRoleRequest)
        {
            var result = await _roleService.Delete(deleteRoleRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateRoleRequest updateRoleRequest)
        {
            var result = await _roleService.Update(updateRoleRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _roleService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _roleService.GetById(id);
            return Ok(result);
        }
    }
}
