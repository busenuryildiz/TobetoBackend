﻿using Business.Abstracts;
using Business.DTOs.Request.Exam;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Entities.Concretes.CoursesFolder;
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

        [HttpPost("Add")]
        [ValidateModel(typeof(CreateExamRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateExamRequest createExamRequest)
        {
            var result = await _examService.Add(createExamRequest);
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteExamRequest deleteExamRequest)
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
        [HttpGet("random-questions/{examId}")]
        public async Task<IActionResult> GetRandomQuestions(int examId)
        {
         
                var questions = await _examService.GetRandomQuestionsByExamId(examId);
                if (questions == null || questions.Count == 0)
                {
                    return NotFound("Sorular bulunamadı.");
                }
                return Ok(questions);
           
           
        }
        [HttpPost("submitExam")]
        public async Task<IActionResult> CalculateExamResult([FromBody] SubmitExamResultDto submitExamResultDto)
        {
            var result = await _examService.SubmitExamResults(submitExamResultDto);
            return Ok(result); // veya isteğe bağlı olarak farklı bir HTTP durumu döndürebilirsiniz.
        }

    }
}