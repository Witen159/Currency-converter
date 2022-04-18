using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverter.Core;
using CurrencyConverter.Data.HttpClients;
using CurrencyConverter.Web.Logging;
using CurrencyConverter.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CurrencyConverter.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CurrencyConverter.Web", Version = "v1"});
            });
            
            services.AddSingleton<ILogger>(_ => new Logger("Logs.txt"));

            services.AddScoped<ICourseProvider, CourseProvider>();
            services.AddScoped<ICurrencyConverter, Core.CurrencyConverter>();


            services.AddHttpClient<ICourseProvider, CourseProvider>((provider, options) =>
            {
                options.BaseAddress = new Uri(Configuration["CurrencyUri"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrencyConverter.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}