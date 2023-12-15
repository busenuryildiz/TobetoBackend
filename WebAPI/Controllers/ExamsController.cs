using Business.Abstract;
using Business.DTOs.Request;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }
        [HttpPost("AddExam")]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var result = await _examService.Add(createExamRequest);
            return Ok(result);
        }

        [HttpPost("DeleteExam")]
        public async Task<IActionResult> Delete([FromBody] DeleteExamRequest deleteExamRequest)
        {
            var result = await _examService.Delete(deleteExamRequest);
            return Ok(result);
        }
        [HttpPost("UpdateExam")]
        public async Task<IActionResult> Update([FromBody] UpdateExamRequest updateExamRequest)
        {
            var result = await _examService.Update(updateExamRequest);
            return Ok(result);
        }

        [HttpGet("GetListExam")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _examService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
