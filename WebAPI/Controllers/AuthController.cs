using Business.Abstracts;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Core.Utilities.JWT;
using Entities.Concretes.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            // Öğrenci kullanıcı doğrulama işlemleri
            UserLoginResponse user = await _userService.Login(model.Email , model.Password);

            if (user != null)
            {
                var userRoles = await _jwtService.GetUserRoles(user.Id);
                var claims = userRoles.Select(role => new Claim(ClaimTypes.Role, role));
                var token = await _jwtService.GenerateToken(user, claims);

                return Ok(new { Token = token, /* Diğer gerekli bilgiler */ });
            }

            else
            {
                return Unauthorized("Authentication failed");
            }
        }

        [Authorize(Roles = "Student")]
        [HttpGet]
        [Route("secured-data")]
        public IActionResult GetSecuredData()
        {
            // Bu noktada öğrenci kullanıcısının kimliği ve rolleri zaten doğrulandı.
            // İlgili işlemleri gerçekleştirin ve sonucu döndürün.
            return Ok("Secured Data for Student");
        }
    }
}
