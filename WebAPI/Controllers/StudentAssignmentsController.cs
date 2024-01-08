using Business.Abstracts;
using Business.DTOs.Request.StudentAssignment;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAssignmentsController : ControllerBase
    {
        IStudentAssignmentService _studentAssignmentService;
        public StudentAssignmentsController(IStudentAssignmentService studentAssignmentService)
        {
            _studentAssignmentService = studentAssignmentService;
        }
        [HttpPost("Add")]
        [ValidateModel(typeof(CreateStudentAssignmentRequestValidator))]

        public async Task<IActionResult> Add([FromBody] CreateStudentAssignmentRequest createStudentAssignmentRequest)
        {
            var result = await _studentAssignmentService.Add(createStudentAssignmentRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentAssignmentRequest deleteStudentAssignmentRequest)
        {
            var result = await _studentAssignmentService.Delete(deleteStudentAssignmentRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentAssignmentRequest updateStudentAssignmentRequest)
        {
            var result = await _studentAssignmentService.Update(updateStudentAssignmentRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentAssignmentService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _studentAssignmentService.GetById(id);
            return Ok(result);
        }
    }
}
