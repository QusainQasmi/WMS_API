using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WMS_API.Data;
using WMS_API.DTO;
using WMS_API.Models;
using WMS_API.Persistence.IServices;

namespace WMS_API.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly CmsDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(CmsDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginRespDto?> Login(LoginDto model)
        {
            var user = await _context.Sys_Users
                .FirstOrDefaultAsync(x =>
                    x.Username == model.Usersame &&
                    x.TenantId == model.TenantId &&
                    x.IsActive == true);

            if (user == null)
                return null;

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

            if (!isValidPassword)
                return null;

            var token = GenerateJwt(user);

            return new LoginRespDto
            {
                Token = token,
                FullName = user.Username,
                UserId = user.Id,
                TenantId = user.TenantId,
            };
        }

        private string GenerateJwt(Sys_Users user)
        {
            var jwtSettings = _config.GetSection("Jwt");

            var claims = new[]
            {
            new Claim("UserId", user.Id.ToString()),
            new Claim("TenantId", user.TenantId.ToString()),
            new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
