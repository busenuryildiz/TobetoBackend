using Business.Abstracts;
using Business.DTOs.Request.District;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        IDistrictService _districtService;
        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateDistrictRequest createDistrictRequest)
        {
            var result = await _districtService.Add(createDistrictRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDistrictRequest deleteDistrictRequest)
        {
            var result = await _districtService.Delete(deleteDistrictRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDistrictRequest updateDistrictRequest)
        {
            var result = await _districtService.Update(updateDistrictRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _districtService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _districtService.GetById(id);
            return Ok(result);
        }
    }
}
