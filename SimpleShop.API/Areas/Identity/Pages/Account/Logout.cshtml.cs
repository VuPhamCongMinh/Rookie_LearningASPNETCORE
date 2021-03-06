using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SimpleShop.API.Configuration;

namespace SimpleShop.API.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IIdentityServerInteractionService _interaction;

        public LogoutModel (SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, IIdentityServerInteractionService interaction)
        {
            _signInManager = signInManager;
            _logger = logger;
            _interaction = interaction;
        }

        public async Task<IActionResult> OnGet (string returnUrl = null)
        {
            return await this.OnPost(returnUrl);
        }

        public async Task<IActionResult> OnPost (string returnUrl = null)
        {
            var requestHeader = HttpContext.Request.Headers["Referer"].ToString();
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            var logoutId = Request.Query["logoutId"].ToString();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else if (!string.IsNullOrEmpty(logoutId))
            {
                var logoutContext = await _interaction.GetLogoutContextAsync(logoutId);
                returnUrl = logoutContext.PostLogoutRedirectUri;

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else if (logoutContext.ClientIds.ElementAt(0) == "react")
                {
                    return Redirect($"{requestHeader}signout-oidc");
                }
                else 
                {
                    return Redirect(requestHeader);
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
