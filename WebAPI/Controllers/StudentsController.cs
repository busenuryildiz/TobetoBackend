using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Student;
using Business.DTOs.Response.Student;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStudent([FromBody] CreateStudentRequest createStudentRequest)
        {
            try
            {
                var result = await _studentService.Add(createStudentRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda loglama yapabilirsiniz.
                Console.WriteLine("Failed to create student. Error: " + ex.Message);

                // Inner exception varsa onu da loglama yapabilirsiniz.
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                }

                return BadRequest("Failed to create student.");
            }
        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var result = await _studentService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Student with ID {id} not found.");
        }

        [HttpDelete("Delete")]
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

        [HttpGet("GetList")]
        public async Task<IActionResult> GetStudentList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
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
