using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClinicAppointments.Models;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
        ClaimsPrincipal ValidateJwtToken(string token);
    }
}