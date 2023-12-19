using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Instructor;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorsController(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddInstructor([FromBody] CreateInstructorRequest createInstructorRequest)
        {
            var result = await _instructorService.Add(createInstructorRequest);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetInstructorById), new { id = result.UserId }, result);
            }
            return BadRequest("Failed to create instructor.");
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetInstructorById(Guid id)
        {
            var result = await _instructorService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Instructor with ID {id} not found.");
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteInstructor(Guid id)
        {
            var deleteRequest = new DeleteInstructorRequest { Id = id };
            var result = await _instructorService.Delete(deleteRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Instructor with ID {id} not found.");
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetInstructorList([FromQuery] PageRequest pageRequest)
        {
            var result = await _instructorService.GetListAsync(pageRequest);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateInstructor([FromBody] UpdateInstructorRequest updateInstructorRequest)
        {
            var result = await _instructorService.Update(updateInstructorRequest);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Instructor with ID {updateInstructorRequest.Id} not found.");
        }
    }
}
