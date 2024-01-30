using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Payment;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        IPaymentService _paymentService;
        private IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        [ValidateModel(typeof(CreatePaymentRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreatePaymentRequest createPaymentRequest)
        {
            var result = await _paymentService.Add(createPaymentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeletePaymentRequest deletePaymentRequest)
        {
            var result = await _paymentService.Delete(deletePaymentRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentRequest updatePaymentRequest)
        {
            var result = await _paymentService.Update(updatePaymentRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _paymentService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _paymentService.GetById(id);
            return Ok(result);
        }
    }
}
