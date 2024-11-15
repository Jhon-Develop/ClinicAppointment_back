using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointments.Extension
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:3000") 
                            .AllowAnyHeader()
                            .AllowAnyMethod()                 
                            .AllowCredentials();               
                });
            });
            return services;
        }
    }
}