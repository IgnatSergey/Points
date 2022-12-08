using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Points.Application.Interfaces;

namespace Points.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
    services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<PointsDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IPointsDbContext>(provider =>
                provider.GetService<PointsDbContext>());
            return services;
        }
    }
}
