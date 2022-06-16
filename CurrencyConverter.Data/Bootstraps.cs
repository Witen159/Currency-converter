using System;
using CurrencyConverter.Core;
using CurrencyConverter.Core.Domains.Users.Repositories;
using CurrencyConverter.Data.HttpClients;
using CurrencyConverter.Data.Users.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection services ,IConfiguration configuration)
        {
            services.AddScoped<ICourseProvider, CourseProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddHttpClient<ICourseProvider, CourseProvider>((options) =>
            {
                options.BaseAddress = new Uri(configuration["CurrencyUri"]);
            });
            return services;
        }
    }
}