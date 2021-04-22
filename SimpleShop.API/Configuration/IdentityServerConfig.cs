using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace SimpleShop.API.Configuration
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
           };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("product.api", "Product Shop API")
             };
        public static IEnumerable<Client> Clients (Dictionary<string, string> clientUrls) =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "product.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                     RedirectUris = { $"{clientUrls["Mvc"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{clientUrls["Mvc"]}/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "product.api",
                    },

                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                },

                //swagger
                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                   RedirectUris =           { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { $"{clientUrls["Swagger"]}/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { $"{clientUrls["Swagger"]}" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "product.api"
                    }
                },
                 new Client
                {
                    ClientName = "react",
                    ClientId = "react",
                    AccessTokenType = AccessTokenType.Reference,
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowAccessTokensViaBrowser = true,

                    RequireClientSecret = false,
                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/signin-oidc",
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientUrls["React"]}/signout-oidc",
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{clientUrls["React"]}"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "product.api"
                    }
                }
            };
    }
}
