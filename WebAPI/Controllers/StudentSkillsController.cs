using AutoMapper;
using Business.Abstracts;
using Business.DTOs.Request.StudentSkill;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSkillsController : ControllerBase
    {
        IStudentSkillService _studentSkillService;
        private IMapper _mapper;

        public StudentSkillsController(IStudentSkillService studentSkillService, IMapper mapper)
        {
            _studentSkillService = studentSkillService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateStudentSkillRequest createStudentSkillRequest)
        {
            var result = await _studentSkillService.Add(createStudentSkillRequest);
            return Ok(result);
        }

        [HttpPost("AddStudentSkillByUserId")]
        public async Task<IActionResult> AddStudentSkillByUserId([FromBody] CreateStudentSkillByUserIdRequest createStudentSkillByUserIdRequest)
        {
            var result = await _studentSkillService.AddStudentSkillByUserId(createStudentSkillByUserIdRequest);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteStudentSkillRequest deleteStudentSkillRequest)
        {
            var result = await _studentSkillService.Delete(deleteStudentSkillRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentSkillRequest updateStudentSkillRequest)
        {
            var result = await _studentSkillService.Update(updateStudentSkillRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _studentSkillService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _studentSkillService.GetById(id);
            return Ok(result);
        }


        [HttpGet("GetStudentSkillsByUserIdAsync")]
        public async Task<IActionResult> GetStudentSkillsByUserIdAsync([FromQuery] Guid userId)
        {
            var result = await _studentSkillService.GetStudentSkillsByUserIdAsync(userId);

            return Ok(result);

        }
    }
}
