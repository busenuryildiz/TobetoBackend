using Business.Abstracts;
using Business.DTOs.Request.Question;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("list")]
        [ValidateModel(typeof(CreateQuestionRequestValidator))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _questionService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionRequest updateQuestionRequest)
        {
            var result = await _questionService.Update(updateQuestionRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteQuestionRequest deleteQuestionRequest)
        {
            var result = await _questionService.Delete(deleteQuestionRequest);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questionService.GetById(id);
            return Ok(result);
        }

        [HttpGet("byExamId/{examId}")]
        public async Task<IActionResult> GetQuestionsByExamId(int examId)
        {
            var result = await _questionService.GetQuestionsByExamId(examId);
            return Ok(result);
        }
    }
}
