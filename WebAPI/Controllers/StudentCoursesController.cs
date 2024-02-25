using Business.Abstracts;
using Business.DTOs.Request.Blog;
using Business.DTOs.Request.StudentCourse;
using Business.Rules.ValidationRules;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        IStudentCourseService _studentCourseService;

        public StudentCoursesController(IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
        }

        [HttpPost("add")]
        [ValidateModel(typeof(CreateStudentCourseRequestValidator))]
        public async Task<IActionResult> Add([FromBody] CreateStudentCourseRequest createStudentCourseRequest)
        {
            var result = await _studentCourseService.Add(createStudentCourseRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteStudentCourseRequest deleteStudentCourseRequest)
        {
            var result = await _studentCourseService.Delete(deleteStudentCourseRequest);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCourseRequest updateStudentCourseRequest)
        {
            var result = await _studentCourseService.Update(updateStudentCourseRequest);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentCourseService.GetById(id);
            return Ok(result);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            var result = await _studentCourseService.GetListAsync(pageRequest);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Diğer seçenekler
            };

            // Json string'i düzenle ve güzel bir şekilde formatla
            var jsonString = System.Text.Json.JsonSerializer.Serialize(result, options);
            var formattedJsonString = JToken.Parse(jsonString).ToString(Formatting.Indented);

            return Ok(formattedJsonString);


        }
        [HttpGet("get-student-courses")]
        public async Task<IActionResult> GetStudentCoursesByStudentId([FromQuery] Guid studentId, [FromQuery] PageRequest pageRequest)
        {
            try
            {
                var result = await _studentCourseService.GetListAsync(studentId, pageRequest);
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    // Diğer seçenekler
                };

                // Json string'i düzenle ve güzel bir şekilde formatla
                var jsonString = System.Text.Json.JsonSerializer.Serialize(result, options);
                var formattedJsonString = JToken.Parse(jsonString).ToString(Formatting.Indented);

                return Ok(formattedJsonString);
            }
            catch (Exception ex)
            {
                // Log the error
                Log.Error(ex, "An error occurred while getting the student courses for StudentId {StudentId}", studentId);

                // Handle the error gracefully and return an appropriate response
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("GetBadgesForCompletedCourses")]
        public async Task<IActionResult> GetBadgesForCompletedCourses([FromQuery] Guid userId)
        {
            var result = await _studentCourseService.GetBadgesForCompletedCourses(userId);

            return Ok(result);
        }
        

        [HttpGet("GetStudentsAllCoursesByUserId")]
        public async Task<IActionResult> GetStudentsAllCoursesByUserId([FromQuery] Guid userId)
        {
            var result = await _studentCourseService.GetStudentsAllCoursesByUserId(userId);

            return Ok(result);
        }
         

        [HttpGet("GetStudentsOngoingCoursesByUserId")]
        public async Task<IActionResult> GetStudentsOngoingCoursesByUserId([FromQuery] Guid userId)
        {
            var result = await _studentCourseService.GetStudentsOngoingCoursesByUserId(userId);

            return Ok(result);
        }

        [HttpGet("GetStudentsCompletedCoursesByUserId")]
        public async Task<IActionResult> GetStudentsCompletedCoursesByUserId([FromQuery] Guid userId)
        {
            var result = await _studentCourseService.GetStudentsCompletedCoursesByUserId(userId);

            return Ok(result);
        }
    }
}
