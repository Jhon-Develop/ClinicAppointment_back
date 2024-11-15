using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Database;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public AuthService(ApplicationDbContext context, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _context = context;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task RegisterAsync(RegisterDto registerDto)
        {
            var userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User") ?? throw new InvalidOperationException("The 'User' role does not exist in the system.");
            var user = new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                PasswordHash = _passwordHasher.HashPassword(registerDto.Password),
                RoleId = userRole.Id,
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                throw new InvalidDataException("The email is not registered or the password is incorrect.");
            }

            if (user.Role == null)
            {
                throw new InvalidOperationException("The user does not have an assigned role.");
            }

            return _jwtService.GenerateJwtToken(user);
        }
    }
}