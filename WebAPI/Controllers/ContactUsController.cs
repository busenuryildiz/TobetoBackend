using Business.Abstracts;
using Business.DTOs.Request.ContactUs;
using Business.DTOs.Request.Email;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {

        IContactUsService _contactUsService;
        IEmailService _emailService;
        public ContactUsController(IContactUsService contactUsService, IEmailService emailService)
        {
            _contactUsService = contactUsService;
            _emailService = emailService;
        }

        [HttpPost("sendMail")]
        public IActionResult SendEmail([FromBody] FromEmailRequestModel model)
        {
            try
            {
                _emailService.SendEmail(model.FromEmail, model.FullName, model.Subject, model.Body);

                return Ok("İletişim Formu başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpPost("Add")]
        //[ValidateModel(typeof(CreateContactUsRequestValidator))]
        //public async Task<IActionResult> Add([FromBody] CreateContactUsRequest createContactUsRequest)
        //{
        //    var result = await _contactUsService.Add(createContactUsRequest);
        //    return Ok(result);
        //}
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteContactUsRequest deleteContactUsRequest)
        {
            var result = await _contactUsService.Delete(deleteContactUsRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateContactUsRequest updateContactUsRequest)
        {
            var result = await _contactUsService.Update(updateContactUsRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _contactUsService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _contactUsService.GetById(id);
            return Ok(result);
        }
    }
}


