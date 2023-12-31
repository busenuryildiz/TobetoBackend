﻿using Business.Abstracts;
using Business.DTOs.Request.LessonCourse;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonCoursesController : ControllerBase
    {
        ILessonCourseService _lessonCourseService;
        public LessonCoursesController(ILessonCourseService lessonCourseService)
        {
            _lessonCourseService = lessonCourseService;
        }
        [HttpPost("Add")]
        [ValidateModel(typeof(CreateLessonCourseRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateLessonCourseRequest createLessonCourseRequest)
        {
            var result = await _lessonCourseService.Add(createLessonCourseRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLessonCourseRequest deleteLessonCourseRequest)
        {
            var result = await _lessonCourseService.Delete(deleteLessonCourseRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLessonCourseRequest updateLessonCourseRequest)
        {
            var result = await _lessonCourseService.Update(updateLessonCourseRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _lessonCourseService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _lessonCourseService.GetById(id);
            return Ok(result);
        }
    }
}
