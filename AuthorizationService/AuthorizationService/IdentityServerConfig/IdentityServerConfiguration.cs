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
        public static List<TestUser> GetTestUsers() =>
            new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username= "test",
                    Password= "test",
                    Claims = new List<Claim>
                    {
                        new Claim("phone_number", "+37529331867"),
                        new Claim("email", "test@gmail.com"),
                        new Claim("isEmailVerified", "yes")
                    }
                },
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username= "test1",
                    Password= "test1",
                    Claims = new List<Claim>
                    {
                        new Claim("phone_number", "+37529333333"),
                        new Claim("email", "test1@gmail.com"),
                        new Claim("isEmailVerified", "no")
                    }
                }
            };
    }
}
