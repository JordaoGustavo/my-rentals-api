using Microsoft.Extensions.DependencyInjection;

namespace MyRentals.Api.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
