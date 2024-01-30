using Business.Abstracts;
using Business.DTOs.Request.City;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _CityService;
        public CitiesController(ICityService CityService)
        {
            _CityService = CityService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateCityRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateCityRequest createCityRequest)
        {
            var result = await _CityService.Add(createCityRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCityRequest deleteCityRequest)
        {
            var result = await _CityService.Delete(deleteCityRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCityRequest updateCityRequest)
        {
            var result = await _CityService.Update(updateCityRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _CityService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _CityService.GetById(id);
            return Ok(result);
        }
    }
}
