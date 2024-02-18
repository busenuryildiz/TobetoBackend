using Business.Abstracts;
using Business.DTOs.Request.Certificate;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        ICertificateService _certificateService;
        public CertificatesController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }


        [HttpPost("Add")]
        [ValidateModel(typeof(CreateCertificateRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateCertificateRequest createCertificateRequest)
        {
            var result = await _certificateService.Add(createCertificateRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCertificateRequest deleteCertificateRequest)
        {
            var result = await _certificateService.Delete(deleteCertificateRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCertificateRequest updateCertificateRequest)
        {
            var result = await _certificateService.Update(updateCertificateRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _certificateService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _certificateService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetUsersAllCertificates")]
        public async Task<IActionResult> GetUsersAllCertificates([FromQuery] Guid userId)
        {
            var result = await _certificateService.GetUsersAllCertificates(userId);

            return Ok(result);
        }
    }
}