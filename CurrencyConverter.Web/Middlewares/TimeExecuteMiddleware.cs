using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CurrencyConverter.Web.Middlewares
{
    public class TimeExecuteMiddleware
    {
        private readonly RequestDelegate next;

        public TimeExecuteMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext) state;
                httpContext.Response.Headers.Add("X-Response-Time-Milliseconds", new[] {stopwatch.ElapsedMilliseconds.ToString()});
                return Task.CompletedTask;
            }, context);

            await next(context);
        }
    }
}