using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4;
using System.Security.Claims;

namespace AuthorizationService.IdentityServerConfig
{
    public static class IdentityServerConfiguration
    {
        public static List<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId= "clientTest",
                    ClientSecrets = new [] {new Secret("innoClinicSecret".Sha512())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId}
                }
            };
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
          new List<IdentityResource>
          {
                  new IdentityResources.OpenId()
          };
    }
}
