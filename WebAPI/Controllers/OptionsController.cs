using Business.Abstracts;
using Business.DTOs.Request.Option;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OptionsController : ControllerBase
    {
        IOptionService _optionService;
        public OptionsController(IOptionService OptionService)
        {
            _optionService = OptionService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateOptionRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateOptionRequest createOptionRequest)
        {
            var result = await _optionService.Add(createOptionRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOptionRequest deleteOptionRequest)
        {
            var result = await _optionService.Delete(deleteOptionRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOptionRequest updateOptionRequest)
        {
            var result = await _optionService.Update(updateOptionRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _optionService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _optionService.GetById(id);
            return Ok(result);
        }
    }
}

