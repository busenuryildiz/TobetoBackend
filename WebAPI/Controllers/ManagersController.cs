using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Manager;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;

        public ManagersController(IManagerService managerService, IMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddManager([FromBody] CreateManagerRequest createManagerRequest)
        {
            var result = await _managerService.Add(createManagerRequest);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetManagerById), new { id = result.UserId }, result);
            }
            return BadRequest("Failed to create manager.");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetManagerById(Guid id)
        {
            var result = await _managerService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Manager with ID {id} not found.");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteManager(Guid id)
        {
            var deleteRequest = new DeleteManagerRequest { Id = id };
            var result = await _managerService.Delete(deleteRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Manager with ID {id} not found.");
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetManagerList([FromQuery] PageRequest pageRequest)
        {
            var result = await _managerService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateManager([FromBody] UpdateManagerRequest updateManagerRequest)
        {
            var result = await _managerService.Update(updateManagerRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Manager with ID {updateManagerRequest.Id} not found.");
        }
    }
}
