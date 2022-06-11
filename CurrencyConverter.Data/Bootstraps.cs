using System;
using CurrencyConverter.Core;
using CurrencyConverter.Data.HttpClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection services ,IConfiguration configuration)
        {
            services.AddScoped<ICourseProvider, CourseProvider>();
            
            services.AddHttpClient<ICourseProvider, CourseProvider>((options) =>
            {
                options.BaseAddress = new Uri(configuration["CurrencyUri"]);
            });
            return services;
        }
    }
}