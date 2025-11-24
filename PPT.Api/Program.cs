using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PPT.Api.Extensions;
using PPT.Application.Mappings;
using PPT.Domain.Entities;
using PPT.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Para habilitar CORS
// Desactivar en Produccion
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// Add services to the container.
// Para la conexion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("name=SQLConnection")
);

// Para los Repositorios y Servicios
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();

// Para AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar migraciones al arrancar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    if (!db.Jugadores.Any())
    {
        db.Jugadores.AddRange(
            new Jugador
            {
                Nombre = "Alfredo Bustamante Mejía"
            },
            new Jugador
            {
                Nombre = "Claudia Patricia Montoya",
            },
            new Jugador
            {
                Nombre = "Karen Bustamante Montoya",
            }
        );
        db.SaveChanges();
    }

    if (!db.Batallas.Any())
    {
        db.Batallas.AddRange(
            new Batalla
            {
                Jugador1Id = 1,
                Jugador2Id = 2,
                GanadorId = 1,
                Fecha = DateTime.Now
            },
            new Batalla
            {
                Jugador1Id = 1,
                Jugador2Id = 2,
                GanadorId = 1,
                Fecha = DateTime.Now
            },
            new Batalla
            {
                Jugador1Id = 1,
                Jugador2Id = 2,
                GanadorId = 2,
                Fecha = DateTime.Now
            },
            new Batalla
            {
                Jugador1Id = 1,
                Jugador2Id = 3,
                GanadorId = 3,
                Fecha = DateTime.Now
            },
            new Batalla
            {
                Jugador1Id = 1,
                Jugador2Id = 3,
                GanadorId = 3,
                Fecha = DateTime.Now
            },
            new Batalla
            {
                Jugador1Id = 3,
                Jugador2Id = 2,
                GanadorId = 3,
                Fecha = DateTime.Now
            }
        );
        db.SaveChanges();
    }
}

// Para habilitar CORS
// Desactivar en Produccion
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();