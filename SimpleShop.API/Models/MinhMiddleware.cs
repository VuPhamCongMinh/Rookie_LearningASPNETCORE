using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SimpleShop.API.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MinhMiddleware
    {
        private readonly RequestDelegate _next;

        public MinhMiddleware (RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke (HttpContext httpContext)
        {
            if (httpContext.User.Identity.Name != null && !httpContext.User.Identity.IsAuthenticated)
            {
                await httpContext.SignOutAsync(IdentityServerConstants.DefaultCookieAuthenticationScheme);
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MinhMiddlewareExtensions
    {
        public static IApplicationBuilder UseMinhMiddleware (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MinhMiddleware>();
        }
    }
}
