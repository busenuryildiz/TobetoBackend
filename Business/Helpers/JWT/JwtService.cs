using Business.Abstracts;
using Business.DTOs.Response.User;
using Business.DTOs.Response.UserRole;
using Entities.Concretes.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserRoleService _userRoleService;

        public JwtService(IOptions<JwtSettings> jwtSettings, IUserRoleService userRoleService)
        {
            _jwtSettings = jwtSettings.Value;
            _userRoleService = userRoleService;
        }

        public async Task<string> GenerateToken(UserLoginResponse user, IEnumerable<Claim> additionalClaims = null)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // Kullanıcı ID'si
        new Claim(ClaimTypes.Email, user.Email),
        // Diğer gerekli claim'ler...
    };

            // Kullanıcının rollerini ekleyin
            var userRoles = await GetUserRoles(user.Id);
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            // Ekstra talep edilen claim'leri ekleyin
            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims);
            }

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<string>> GetUserRoles(Guid userId)
        {
            var response = await _userRoleService.GetRolesByUserId(userId);
            return response.Roles;
        }



    }

}
