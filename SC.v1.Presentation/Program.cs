using Serilog;
using SC.v1.Data.Domain.Models;
using Microsoft.EntityFrameworkCore;
using SC.v1.Presentation.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configurar Serilog para registrar eventos de nivel de información o superior en el archivo de log
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Agregar el servicio de logging de Serilog
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog(dispose: true);
});

// Agregar el servicio de DbContext para Entity Framework
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyCompanyContext>(options => options.UseNpgsql(connectionString));

// Agregar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Agregar los controladores y configurar Swagger
builder.Services.AddControllers();

builder.ConfigureAppInversionOfControl();

builder.ConfigureLocalization();

if (builder.Environment.IsDevelopment())
{
    builder.ConfigureOpenApi();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApiDoc(builder.Configuration);
}

if (app.Environment.IsDevelopment())
{
    app.UseCors(builder => builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
