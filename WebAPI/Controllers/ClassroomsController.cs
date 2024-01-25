using Business.Abstracts;
using Business.DTOs.Request.Classroom;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        IClassroomService _classroomService;
        public ClassroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateClassroomRequest createClassroomRequest)
        {
            try
            {
                var result = await _classroomService.Add(createClassroomRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"İç Hata: {ex.InnerException.Message}");
                }
                return StatusCode(500, "Bir hata oluştu, lütfen daha sonra tekrar deneyin.");
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteClassroomRequest deleteClassroomRequest)
        {
            var result = await _classroomService.Delete(deleteClassroomRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateClassroomRequest updateClassroomRequest)
        {
            var result = await _classroomService.Update(updateClassroomRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _classroomService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var result = await _classroomService.GetById(id);
            return Ok(result);
        }
    }
}
