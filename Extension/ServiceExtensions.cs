using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ClinicAppointments.Repositories;
using ClinicAppointments.Repositories.Interfaces;
using ClinicAppointments.Services;
using ClinicAppointments.Services.Interfaces;

namespace ClinicAppointments.Extension
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IAppointmentHistoryRepository, AppointmentHistoryRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IAppointmentHistoryService, AppointmentHistoryService>();
        }
    }
}