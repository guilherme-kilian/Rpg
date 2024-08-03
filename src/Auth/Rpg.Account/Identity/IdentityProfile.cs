using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Rpg.Account.Identity;

public class IdentityProfile
{
    private readonly IEnumerable<IdentitySettings> _settings;

    public IdentityProfile(IEnumerable<IdentitySettings> settings)
    {
        _settings = settings;
    }

    public IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

    public IEnumerable<ApiScope> GetApiScopes() => _settings.Select(s => new ApiScope(s.Name, s.DisplayName));

    public IEnumerable<Client> GetClients()
    {
        var clients = _settings.Select(s => new Client
        {

            ClientId = s.ClientId,
            ClientName = s.ClientName,
            AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
            ClientSecrets = { new Secret(s.ClientSecret.Sha256()) },
            RedirectUris = { $"https://localhost:8003/signin-oidc" },
            PostLogoutRedirectUris = { "https://localhost:8003/signout-callback-oidc" },
            AllowedScopes = new List<string>
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            s.Scope,
        },
            AllowOfflineAccess = true,
        }).ToList();

        clients.Add(new()
        {
            ClientId = "bff",

            ClientSecrets =
            {
                new Secret("batata123".Sha256())
            },

            AllowedGrantTypes = GrantTypes.Code,

            RedirectUris = { "https://localhost:8002/signin-oidc" },
            FrontChannelLogoutUri = "https://localhost:8002/signout-oidc",
            PostLogoutRedirectUris = { "https://localhost:8002/signout-callback-oidc" },

            AllowOfflineAccess = true,

            AllowedScopes = { "openid", "profile", "remote_api", "api-rpg" }
        });

        return clients;
    }
}
