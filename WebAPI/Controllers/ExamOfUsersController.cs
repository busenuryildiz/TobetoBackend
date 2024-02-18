using Business.Abstracts;
using Business.DTOs.Request.ExamOfUser;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamOfUsersController : ControllerBase
    {
        IExamOfUserService _examOfUserService;
        public ExamOfUsersController(IExamOfUserService examOfUserService)
        {
            _examOfUserService = examOfUserService;
        }


        [HttpPost("Add")]
        //[ValidateModel(typeof(CreateExamOfUserRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateExamOfUserRequest createExamOfUserRequest)
        {
            var result = await _examOfUserService.Add(createExamOfUserRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteExamOfUserRequest deleteExamOfUserRequest)
        {
            var result = await _examOfUserService.Delete(deleteExamOfUserRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateExamOfUserRequest updateExamOfUserRequest)
        {
            var result = await _examOfUserService.Update(updateExamOfUserRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _examOfUserService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _examOfUserService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetUsersExamResultInfo")]
        public async Task<IActionResult> GetUsersExamResultInfo([FromQuery] Guid userId)
        {
            var result = await _examOfUserService.GetUsersExamResultInfo(userId, int.MaxValue);
            return Ok(result);
        }
    }
}
