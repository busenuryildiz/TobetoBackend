using Business.Abstracts;
using Business.DTOs.Request.County;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CountiesController : ControllerBase
    {
        ICountyService _countyService;
        public CountiesController(ICountyService countyService)
        {
            _countyService = countyService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCountyRequest createCountyRequest)
        {
            var result = await _countyService.Add(createCountyRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCountyRequest deleteCountyRequest)
        {
            var result = await _countyService.Delete(deleteCountyRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCountyRequest updateCountyRequest)
        {
            var result = await _countyService.Update(updateCountyRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _countyService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _countyService.GetById(id);
            return Ok(result);
        }
    }
}
