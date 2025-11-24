using PPT.Application.Interfaces;
using PPT.Application.Services;
using PPT.Domain.Interfaces;
using PPT.Infrastructure.Data.Repositories;

namespace PPT.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IJugadorRepository, JugadorRepository>();
            repositories.AddScoped<IBatallaRepository, BatallaRepository>();

        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IJugadorService, JugadorService>();
            services.AddScoped<IBatallaService, BatallaService>();
        }
    }
}
