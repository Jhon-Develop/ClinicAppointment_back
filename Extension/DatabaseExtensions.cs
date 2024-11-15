using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicAppointments.Database;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointments.Extension
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            Env.Load();

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbDatabaseName = Environment.GetEnvironmentVariable("DB_DATABASE");
            var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (string.IsNullOrEmpty(dbHost) ||
                string.IsNullOrEmpty(dbPort) ||
                string.IsNullOrEmpty(dbDatabaseName) ||
                string.IsNullOrEmpty(dbUser) ||
                string.IsNullOrEmpty(dbPassword))
            {
                throw new InvalidOperationException("Faltan variables de entorno para la configuración de la base de datos.");
            }

            var connectionDB = $"server={dbHost};port={dbPort};database={dbDatabaseName};uid={dbUser};password={dbPassword}";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connectionDB, ServerVersion.Parse("8.0.20-mysql")));

            return services;
        }
    }
}