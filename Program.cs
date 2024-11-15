using DotNetEnv;
using ClinicAppointments.Extension;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseConfiguration();
builder.Services.AddCorsConfiguration();  // Agrega la configuración de CORS
builder.Services.AddSwaggerConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

// Middleware para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Middleware de Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicAppointments API V1");
});

// Middleware para redirigir la raíz a Swagger
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }
    await next();
});

// Middleware de CORS
app.UseCors("AllowAllOrigins");  // Cambiado a "AllowAllOrigins" para coincidir con la configuración

// Habilitar archivos estáticos
app.UseStaticFiles();

// Autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapeo de controladores
app.MapControllers();

app.Run();
