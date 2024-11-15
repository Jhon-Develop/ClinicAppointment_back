using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models.DTOs;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto registerDto);
        Task<string> LoginAsync(LoginDto loginDto);
    }
}