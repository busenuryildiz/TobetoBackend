using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.Subject;
using Business.DTOs.Response.Subject;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSubjects([FromQuery] PageRequest pageRequest)
        {
            try
            {
                var result = await _subjectService.GetAllSubjectsAsync(pageRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir şekilde işleyin veya loglayın.
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            var subjectResponse = _mapper.Map<SubjectResponse>(subject);
            return Ok(subjectResponse);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSubject([FromBody] CreateSubjectRequest request)
        {
            var addedSubject = await _subjectService.AddSubjectAsync(request);
            var subjectResponse = _mapper.Map<SubjectResponse>(addedSubject);

            return CreatedAtAction(nameof(GetSubjectById), new { id = subjectResponse.Id }, subjectResponse);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] UpdateSubjectRequest request)
        {
            var existingSubject = await _subjectService.GetSubjectByIdAsync(id);

            if (existingSubject == null)
            {
                return NotFound();
            }

            var updatedSubject = await _subjectService.UpdateSubjectAsync(request);
            var subjectResponse = _mapper.Map<SubjectResponse>(updatedSubject);

            return Ok(subjectResponse);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var success = await _subjectService.DeleteSubjectAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
