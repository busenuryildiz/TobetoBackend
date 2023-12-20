using Business.Abstracts;
using Business.DTOs.Request.Exam;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var result = await _examService.Add(createExamRequest);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteExamRequest deleteExamRequest)
        {
            var result = await _examService.Delete(deleteExamRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateExamRequest updateExamRequest)
        {
            var result = await _examService.Update(updateExamRequest);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _examService.GetById(id);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _examService.GetListAsync(pageRequest);
            return Ok(result);
        }
    }
}
