using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRentals.Api.Application.Contracts.Persistence;
using MyRentals.Api.Persistence.Repositories;

namespace MyRentals.Api.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
