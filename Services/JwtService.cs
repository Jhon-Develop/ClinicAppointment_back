using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ClinicAppointments.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _jwtKey;
        private readonly int _jwtExpireMinutes;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;

        public JwtService(IConfiguration configuration)
        {
            _jwtKey = configuration["JWT_KEY"] ?? throw new InvalidOperationException("JWT Key is not configured.");
            _jwtExpireMinutes = int.Parse(configuration["JWT_EXPIRE_MINUTES"] ?? "30");
            _jwtIssuer = configuration["JWT_ISSUER"] ?? throw new InvalidOperationException("JWT Issuer is not configured.");
            _jwtAudience = configuration["JWT_AUDIENCE"] ?? throw new InvalidOperationException("JWT Audience is not configured.");
        }

        public string GenerateJwtToken(User user)
        {
            if (string.IsNullOrEmpty(_jwtKey))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }

            if (user.Role == null || string.IsNullOrEmpty(user.Role.Name))
            {
                throw new InvalidOperationException("User role is not set.");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddMinutes(_jwtExpireMinutes).ToString("yyyy-MM-dd HH:mm:ss"))
            };

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtExpireMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey)), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtKey);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _jwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = _jwtAudience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
    }
}