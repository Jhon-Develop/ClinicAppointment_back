using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;

namespace ClinicAppointments.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserDto userDto);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(int id, UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}