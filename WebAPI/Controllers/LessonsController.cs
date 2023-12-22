using Business.Concretes;
using Business.DTOs.Request.Lesson;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly LessonManager _lessonManager;

        public LessonController(LessonManager lessonManager)
        {
            _lessonManager = lessonManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson([FromBody] CreateLessonRequest createLessonRequest)
        {
            try
            {
                var result = await _lessonManager.Add(createLessonRequest);
                return CreatedAtAction(nameof(GetLessonById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            try
            {
                var deleteRequest = new DeleteLessonRequest { Id = id };
                var result = await _lessonManager.Delete(deleteRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            try
            {
                var result = await _lessonManager.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLessonList([FromQuery] PageRequest pageRequest)
        {
            try
            {
                var result = await _lessonManager.GetListAsync(pageRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLesson([FromBody] UpdateLessonRequest updateLessonRequest)
        {
            try
            {
                var result = await _lessonManager.Update(updateLessonRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return BadRequest(ex.Message);
            }
        }
    }
}
