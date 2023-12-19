using Azure.Core;
using Business.Abstracts;
using Business.DTOs.Request.User;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
        {
            var result = await _userService.Add(createUserRequest);
            return Ok(result);
        }



        //[HttpPost("Add")]
        //public async Task<IActionResult> Add([FromBody] CreateUserRequest createUserRequest)
        //{


        //if (createUserRequest == null)
        //{
        //    return BadRequest("Geçersiz istek");
        //}

        //var newUser = new User
        //{
        //    FirstName = createUserRequest.FirstName,
        //    LastName = createUserRequest.LastName,
        //    Email = createUserRequest.Email,
        //};

        //if (createUserRequest.IsStudent)
        //{
        //    // Öğrenci ile ilgili işlemleri gerçekleştirin
        //    var newStudent = new Student();
        //    newStudent.GenerateStudentNumber();
        //    newUser.Student = newStudent;
        //    // Diğer öğrenci özellikleri buraya ekleyin
        //}

        //if (createUserRequest.IsInstructor)
        //{
        //    // Öğretmen ile ilgili işlemleri gerçekleştirin
        //    newUser.Instructor = new Instructor
        //    {
        //        // Diğer öğretmen özellikleri buraya ekleyin
        //    };
        //}

        //    _userService.Add(createUserRequest);

        //    return Ok("Kullanıcı başarıyla oluşturuldu.");
        //}
        //var result = await _userService.Add(createUserRequest);
        //return Ok(result);


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest deleteUserRequest)
        {
            var result = await _userService.Delete(deleteUserRequest);
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest updateUserRequest)
        {
            var result = await _userService.Update(updateUserRequest);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

    }
}
