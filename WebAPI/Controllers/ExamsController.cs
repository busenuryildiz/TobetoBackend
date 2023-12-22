using Business.Abstracts;
using Business.DTOs.Request.Exam;
using Business.DTOs.Request.Exam;
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


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var result = await _examService.Add(createExamRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteExamRequest deleteExamRequest)
        {
            var result = await _examService.Delete(deleteExamRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateExamRequest updateExamRequest)
        {
            var result = await _examService.Update(updateExamRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _examService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetListRandomQuestions([FromQuery] int examId)
        {
            var result = await _examService.GetRandomQuestionsByExamId(examId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _examService.GetById(id);
            return Ok(result);
        }
    }
}
