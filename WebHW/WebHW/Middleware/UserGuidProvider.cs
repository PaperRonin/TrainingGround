using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebHW.Middleware
{
    public class UserGuidProvider
    {
        private readonly RequestDelegate next;

        public UserGuidProvider(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies["UserGUID"] == null)
            {
                context.Response.OnStarting(() =>
                {
                    CookieOptions options = new CookieOptions {Expires = DateTime.Now.AddDays(1)};
                    context.Response.Cookies.Append("UserGUID", Guid.NewGuid().ToString(), options);
                    GlobalVariables.ViewCount++;
                    return Task.CompletedTask;
                });
            }

            await next(context);
        }
    }

    public static class Extension
    {
        public static IApplicationBuilder UserGuidProvider(this IApplicationBuilder app)
        {
            return app.UseMiddleware<UserGuidProvider>();
        }
    }
}
