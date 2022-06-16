using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CurrencyConverter.Web.Middlewares
{
    public static class AuthenticationMiddleware
    {
        public static void UseCustomAuthentication(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.StartsWithSegments("/user"))
                {
                    if (!context.Request.Headers.TryGetValue("Role", out var role) || role != "admin")
                    {
                        context.Response.StatusCode = (int) StatusCodes.Status403Forbidden;
                        return;
                    }
                }
                await next();
            });
        }
    }
}