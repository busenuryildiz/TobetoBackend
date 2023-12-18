﻿using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentRequest createStudentRequest)
        {
            var result = await _studentService.Add(createStudentRequest);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetStudentById), new { id = result.UserId }, result);
            }
            return BadRequest("Failed to create student.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await _studentService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Student with ID {id} not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var deleteRequest = new DeleteStudentRequest { Id = id };
            var result = await _studentService.Delete(deleteRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Student with ID {id} not found.");
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetStudentList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentRequest updateStudentRequest)
        {
            var result = await _studentService.Update(updateStudentRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Student with ID {updateStudentRequest.Id} not found.");
        }
    }
}
