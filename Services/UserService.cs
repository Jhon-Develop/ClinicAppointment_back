using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Models;
using ClinicAppointments.Models.DTOs;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services.Interfaces;

namespace ClinicAppointments.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        // Crear un nuevo usuario
        public async Task<User> CreateUserAsync(UserDto userDto)
        {
            // Encriptamos la contraseña utilizando el PasswordHasher
            var hashedPassword = _passwordHasher.HashPassword(userDto.Password);

            // Creamos un nuevo usuario
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                RoleId = userDto.RoleId,
                DoctorId = userDto.DoctorId,
                PasswordHash = hashedPassword // Guardamos la contraseña encriptada
            };

            return await _userRepository.AddUserAsync(user);
        }

        // Obtener un usuario por su ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        // Obtener todos los usuarios
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        // Actualizar un usuario
        public async Task<User> UpdateUserAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.RoleId = userDto.RoleId;
            user.DoctorId = userDto.DoctorId;

            return await _userRepository.UpdateUserAsync(user);
        }

        // Eliminar un usuario
        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        // Verificar la contraseña
        public bool VerifyPassword(string password, string hashedPassword)
        {
            return _passwordHasher.VerifyPassword(password, hashedPassword);
        }
    }
}
