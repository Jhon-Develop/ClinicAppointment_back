using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Services.Interfaces;

namespace ClinicAppointments.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("The password cannot be empty.", nameof(password));

            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("The password cannot be empty.", nameof(password));

            if (string.IsNullOrEmpty(hashedPassword))
                throw new ArgumentException("The Hash of password cannot be empty.", nameof(hashedPassword));

            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}