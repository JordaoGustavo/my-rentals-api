using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my_rentals.Infrastructure.Persistence;

namespace my_rentals.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentsCoreDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("RentsCoreDbConnectionString")));

            return services;
        }
    }
}
