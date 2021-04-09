using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SimpleShop.Shared.Interfaces;
using SimpleShop.UI.Services;

namespace SimpleShop.UI.Extensions
{
    public static class HttpClientRegister
    {
        public static void AddRegisterHttpClient (this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var configureClient = new Action<IServiceProvider, HttpClient>(async (provider, client) =>
            {
                var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");

                client.BaseAddress = new Uri("https://localhost:44348");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            });

            services.AddHttpClient<IHttpClientService, HttpClientService>(configureClient);
        }
    }
}
