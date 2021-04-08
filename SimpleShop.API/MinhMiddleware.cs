using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MinhMiddleware
    {
        private readonly RequestDelegate _next;

        public MinhMiddleware (RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke (HttpContext httpContext)
        {

            return _next(httpContext);
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
