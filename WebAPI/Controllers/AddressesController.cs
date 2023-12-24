using Business.Abstracts;
using Business.DTOs.Request.Address;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressService _addressService;
        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateAddressRequest createAddressRequest)
        {
            var result = await _addressService.Add(createAddressRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteAddressRequest deleteAddressRequest)
        {
            var result = await _addressService.Delete(deleteAddressRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAddressRequest updateAddressRequest)
        {
            var result = await _addressService.Update(updateAddressRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _addressService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _addressService.GetById(id);
            return Ok(result);
        }
    }
}
