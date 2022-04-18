using System;
using System.Threading.Tasks;
using CurrencyConverter.Web.Logging;
using Microsoft.AspNetCore.Http;

namespace CurrencyConverter.Web.Middlewares
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                logger.Log(e);

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new {Message = "Внутренняя ошибка"});
            }
        }
    }
}