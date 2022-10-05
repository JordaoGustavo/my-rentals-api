using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using my_rentals.Application.Contracts.Services;
using my_rentals.Application.Services;

namespace my_rentals.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPropertyService, PropertyService>();

            return services;
        }
    }
}
