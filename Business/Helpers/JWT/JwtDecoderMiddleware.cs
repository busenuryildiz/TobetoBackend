using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtDecoderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;

        public JwtDecoderMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSettings)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _jwtSettings = jwtSettings?.Value ?? throw new ArgumentNullException(nameof(jwtSettings));
        }

        public async Task Invoke(HttpContext context)
        {
            // JWT token al
            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(jwtToken))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetTokenValidationParameters();

                try
                {
                    // JWT token'ı çöz
                    var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out _);

                    // JWT token başarıyla çözüldü, şimdi claims (id, rol, vb.) alabiliriz.
                    var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var userEmail = claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
                    var userRoles = claimsPrincipal.FindAll(ClaimTypes.Role).Select(c => c.Value);

                    // İhtiyaç duyulan bilgileri kullanabilirsiniz
                    context.Items["UserId"] = userId;
                    context.Items["UserEmail"] = userEmail;
                    context.Items["UserRoles"] = userRoles;
                }
                catch (SecurityTokenValidationException ex)
                {
                    // JWT validasyon hatası
                    context.Response.StatusCode = 401; // Unauthorized
                    await context.Response.WriteAsync($"JWT Validation Error: {ex.Message}");
                    return;
                }
            }

            // Sonraki Middleware'e devam et
            await _next(context);
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
            };
        }
    }

    public static class JwtDecoderMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtDecoderMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtDecoderMiddleware>();
        }
    }
}
