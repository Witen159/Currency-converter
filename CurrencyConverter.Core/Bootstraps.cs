using CurrencyConverter.Core.Domains.Users.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Core
{
    public static class Bootstrap
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyConverter, Core.CurrencyConverter>(); 
            services.AddScoped<IUserService, UserService>();
            
            return services;
        }
    }
}