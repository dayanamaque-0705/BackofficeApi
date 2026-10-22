using Backoffice.Services;
using Backoffice.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//configurar la cadena de conexión a la base de datos MySQL desde el archivo de configuración (appsettings.json) y se lanza una excepción si no se encuentra la cadena de conexión.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
??throw new InvalidOperationException("falta la cadena de conexion DefaultConnection");

// Add services to the container.
//se crea el contexto de base de datos y se configura para usar MySQL con la cadena de conexión proporcionada. Se utiliza ServerVersion.AutoDetect para detectar automáticamente la versión del servidor MySQL.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<ICategoriaService, CategoriaServiceMemoria>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
