
using Microsoft.Extensions.DependencyInjection;

namespace SoftZone.BLL
{
    public static class BllServiceExtension
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Register Services
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}

