//using Business.Abstracts;
//using Business.DTOs.Request.Student;
//using Core.DataAccess.Paging;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsController : ControllerBase
//    {
//        IStudentService _studentService;
//        public StudentsController(IStudentService studentService)
//        {
//            _studentService = studentService;
//        }
//        [HttpPost("Add")]
//        public async Task<IActionResult> Add([FromBody] CreateStudentRequest createStudentRequest)
//        {
//            var result = await _studentService.Add(createStudentRequest);
//            return Ok(result);
//        }

//        [HttpPost("Delete")]
//        public async Task<IActionResult> Delete([FromBody] DeleteStudentRequest deleteStudentRequest)
//        {
//            var result = await _studentService.Delete(deleteStudentRequest);
//            return Ok(result);
//        }
//        [HttpPost("Update")]
//        public async Task<IActionResult> Update([FromBody] UpdateStudentRequest updateStudentRequest)
//        {
//            var result = await _studentService.Update(updateStudentRequest);
//            return Ok(result);
//        }

//        [HttpGet("GetList")]
//        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
//        {
//            var result = await _studentService.GetListAsync(pageRequest);
//            return Ok(result);
//        }
//        [HttpGet("GetById")]
//        public async Task<IActionResult> GetById([FromQuery] Guid id)
//        {
//            var result = await _studentService.GetById(id);
//            return Ok(result);
//        }

//    }
//}

