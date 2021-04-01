using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShop.WebAPI.Configuration
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<ApiScope> ApiScopes =>
          new List<ApiScope>
          {
                new ApiScope("product.api", "Product API")
          };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "clientId",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("tophokhonghanh".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "product.api" }
                }
            };
    }
}
