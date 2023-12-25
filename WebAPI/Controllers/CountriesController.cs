using Business.Abstracts;
using Business.DTOs.Request.Country;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        ICountryService _countryService;
        public CountrysController(ICountryService CountryService)
        {
            _countryService = CountryService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateCountryRequest createCountryRequest)
        {
            var result = await _countryService.Add(createCountryRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCountryRequest deleteCountryRequest)
        {
            var result = await _countryService.Delete(deleteCountryRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCountryRequest updateCountryRequest)
        {
            var result = await _countryService.Update(updateCountryRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _countryService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _countryService.GetById(id);
            return Ok(result);
        }
    }
}
