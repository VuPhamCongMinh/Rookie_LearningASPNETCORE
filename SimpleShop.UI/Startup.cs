using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SimpleShop.Shared.Interfaces;
using SimpleShop.UI.Extensions;
using SimpleShop.UI.Models;
using SimpleShop.UI.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleShop.UI
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddRegisterHttpClient(Configuration);

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Events = new CookieAuthenticationEvents
                    {
                        // After the auth cookie has been validated, this event is called.
                        // In it we see if the access token is close to expiring.  If it is
                        // then we use the refresh token to get a new access token and save them.
                        // If the refresh token does not work for some reason then we redirect to 
                        // the login screen.
                        OnValidatePrincipal = async cookieCtx =>
                        {
                            var now = DateTimeOffset.UtcNow;
                            var expiresAt = cookieCtx.Properties.GetTokenValue("expires_at");
                            var accessToken = cookieCtx.Properties.GetTokenValue("access_token");
                            var accessTokenExpiration = DateTimeOffset.Parse(expiresAt);
                            var timeRemaining = accessTokenExpiration.Subtract(now);
                            // TODO: Get this from configuration with a fall back value.
                            var refreshThresholdMinutes = 5;
                            //var refreshThresholdMinutes = 90;
                            var refreshThreshold = TimeSpan.FromMinutes(refreshThresholdMinutes);

                            if (timeRemaining < refreshThreshold)
                            {
                                var refreshToken = cookieCtx.Properties.GetTokenValue("refresh_token");
                                var client = new HttpClient();
                                client.DefaultRequestHeaders.Add("Bearer", accessToken);
                                DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync("https://localhost:44348/");
                                // TODO: Get this HttpClient from a factory
                                var response = await new HttpClient().RequestRefreshTokenAsync(new RefreshTokenRequest
                                {
                                    Address = disco.TokenEndpoint,
                                    ClientId = "mvc",
                                    ClientSecret = "secret",
                                    RefreshToken = refreshToken
                                });

                                if (!response.IsError)
                                {
                                    var expiresInSeconds = response.ExpiresIn;
                                    var updatedExpiresAt = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds);
                                    cookieCtx.Properties.UpdateTokenValue("expires_at", updatedExpiresAt.ToString());
                                    cookieCtx.Properties.UpdateTokenValue("access_token", response.AccessToken);
                                    cookieCtx.Properties.UpdateTokenValue("refresh_token", response.RefreshToken);

                                    // Indicate to the cookie middleware that the cookie should be remade (since we have updated it)
                                    cookieCtx.ShouldRenew = true;
                                }
                                else
                                {
                                    cookieCtx.RejectPrincipal();
                                    await cookieCtx.HttpContext.SignOutAsync();
                                }
                            }
                        }
                    };
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:44348";
                    options.RequireHttpsMetadata = false;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("product.api");
                    options.Scope.Add("offline_access");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };

                    options.Events = new OpenIdConnectEvents
                    {
                        OnAccessDenied = context =>
                        {
                            context.HttpContext.SignOutAsync("Cookies");
                            context.Response.Redirect("/");
                            context.HandleResponse();

                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                      {
                          context.HttpContext.SignOutAsync("Cookies");
                          context.Response.Redirect("/");
                          context.HandleResponse();

                          return Task.CompletedTask;
                      },
                        OnRemoteFailure = context =>
                        {
                            context.HttpContext.SignOutAsync("Cookies");
                            context.Response.Redirect("/");
                            context.HandleResponse();

                            return Task.CompletedTask;
                        }
                    };

                });


            //services.AddScoped<IHttpClientService, HttpClientService>();

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
