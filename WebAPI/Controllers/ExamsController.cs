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
            _examService = examService ?? throw new ArgumentNullException(nameof(examService));
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetExams([FromQuery] PageRequest pageRequest)
        {
            var exams = await _examService.GetListAsync(pageRequest);
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var exam = await _examService.GetInfoById(id);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddExam([FromBody] CreateExamRequest createExamRequest)
        {
            var createdExam = await _examService.Add(createExamRequest);
            return CreatedAtAction(nameof(GetExamById), new { id = createdExam.Id }, createdExam);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateExam([FromBody] UpdateExamRequest updateExamRequest)
        {
            var updatedExam = await _examService.Update(updateExamRequest);
            return Ok(updatedExam);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var deleteExamRequest = new DeleteExamRequest { Id = id };
            var deletedExam = await _examService.Delete(deleteExamRequest);
            return Ok(deletedExam);
        }

        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetExamsByCourseId(int courseId)
        {
            var exams = await _examService.GetExamsByCourseId(courseId);
            return Ok(exams);
        }
    }
}
