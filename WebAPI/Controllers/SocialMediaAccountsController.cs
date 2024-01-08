using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.SocialMediaAccount;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaAccountsController : ControllerBase
    {
        ISocialMediaAccountService _socialMediaAccountService;
        private IMapper _mapper;

        public SocialMediaAccountsController(ISocialMediaAccountService socialMediaAccountService, IMapper mapper)
        {
            _socialMediaAccountService = socialMediaAccountService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        [ValidateModel(typeof(CreateSocialMediaAccountRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaAccountRequest createSocialMediaAccountRequest)
        {
            var result = await _socialMediaAccountService.Add(createSocialMediaAccountRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialMediaAccountRequest deleteSocialMediaAccountRequest)
        {
            var result = await _socialMediaAccountService.Delete(deleteSocialMediaAccountRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaAccountRequest updateSocialMediaAccountRequest)
        {
            var result = await _socialMediaAccountService.Update(updateSocialMediaAccountRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _socialMediaAccountService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _socialMediaAccountService.GetById(id);
            return Ok(result);
        }
    }
}
