using Business.Abstracts;
using Business.DTOs.Request.User;
using Business.DTOs.Response.User;
using Core.Utilities.JWT;
using Entities.Concretes.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Claims;
using Business.DTOs.Request.Email;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;
        private readonly IEmailService _emailService;

        public AuthController(IUserService userService, JwtService jwtService, IEmailService emailService)
        {
            _userService = userService;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            // Öğrenci kullanıcı doğrulama işlemleri
            UserLoginResponse user = await _userService.Login(model.Email, model.Password);

            if (user != null)
            {
                var userRoles = await _jwtService.GetUserRoles(user.Id);
                var claims = userRoles.Select(role => new Claim(ClaimTypes.Role, role));
                var token = await _jwtService.GenerateToken(user, claims);

                return Ok(new { Token = token, User =  user });
            }

            else
            {
                return Unauthorized("Authentication failed");
            }
         
        }


        [HttpGet("decode")]
        public IActionResult DecodeJwtToken()
        {
            // Önceki middleware tarafından eklenen bilgileri al
            var userId = HttpContext.Items["UserId"]?.ToString();
            var userEmail = HttpContext.Items["UserEmail"]?.ToString();
            var userRoles = HttpContext.Items["UserRoles"] as IEnumerable<string>;

            // Bu bilgileri kullanarak istediğiniz işlemleri yapabilirsiniz
            // Örneğin, bu bilgileri kullanarak bir response dönebilirsiniz
            var response = new
            {
                UserId = userId,
                Email = userEmail,
                Roles = userRoles
            };

            return Ok(response);
        }

        [AuthorizeRole("string", "Admin")]
        [HttpGet]
        [Route("secured-data")]
        public IActionResult GetSecuredData()
        {
            // Bu noktada öğrenci kullanıcısının kimliği ve rolleri zaten doğrulandı.
            // İlgili işlemleri gerçekleştirin ve sonucu döndürün.
            return Ok("Secured Data for Student");
        }




        [HttpPost("forgetPassword")]
        public IActionResult ForgetPassword([FromBody] ResetPasswordEmailRequest model)
        {
            try
            {
                _emailService.ForgetPassword(model.Email);

                return Ok("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    }
