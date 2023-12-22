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
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var exams = await _examService.GetListAsync(pageRequest);
            return Ok(exams);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var exam = await _examService.GetById(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var createdExam = await _examService.Add(createExamRequest);
            return CreatedAtAction(nameof(GetById), new { id = createdExam.Id }, createdExam);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateExamRequest updateExamRequest)
        {
            // Ensure the request ID matches the route parameter
            if (id != updateExamRequest.Id)
            {
                return BadRequest();
            }

            var updatedExam = await _examService.Update(updateExamRequest);
            if (updatedExam == null)
            {
                return NotFound();
            }

            return Ok(updatedExam);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedExam = await _examService.Delete(new DeleteExamRequest { Id = id });
            if (deletedExam == null)
            {
                return NotFound();
            }

            return Ok(deletedExam);
        }

        [HttpGet("GetExamsByCourseId")]
        public async Task<IActionResult> GetExamsByCourseId(int courseId)
        {
            var exams = await _examService.GetExamsByCourseId(courseId);
            return Ok(exams);
        }

        [HttpGet("GetRandomQuestionsByExamId")]
        public async Task<IActionResult> GetRandomQuestionsByExamId(int examId)
        {
            var questions = await _examService.GetRandomQuestionsByExamId(examId);
            return Ok(questions);
        }
    }
}