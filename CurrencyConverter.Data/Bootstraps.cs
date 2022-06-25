using System;
using CurrencyConverter.Core;
using CurrencyConverter.Core.Domains.Users.Repositories;
using CurrencyConverter.Data.HttpClients;
using CurrencyConverter.Data.Users.Repositories;
using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddHttpClient<ICourseProvider, CourseProvider>((options) =>
            {
                options.BaseAddress = new Uri(configuration["CurrencyUri"]);
            });
            services.AddDbContext<ConverterContext>(options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(
                "Host=localhost;Port=5432;Database=converter-test;Username=postgres;Password=Madmanp159"));
            return services;
        }
    }
}