using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my_rentals.Application.Contracts.Repositories;
using my_rentals.Infrastructure.Persistence;
using my_rentals.Infrastructure.Repositories;

namespace my_rentals.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentsCoreDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("RentsCoreDbConnectionString")));

            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();

            return services;
        }
    }
}
