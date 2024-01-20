using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Rpg.Account.Api.Configuration.Services;

public class IdentityProfile
{
    private readonly IEnumerable<IdentitySettings> _settings;

    public IdentityProfile(IEnumerable<IdentitySettings> settings)
    {
        _settings = settings;
    }

    public IEnumerable<IdentityResource> GetResources() => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

    public IEnumerable<ApiScope> GetApiScopes() => _settings.Select(s => new ApiScope(s.Name, s.DisplayName));

    public IEnumerable<Client> GetClients() => _settings.Select(s => new Client
    {

        ClientId = s.ClientId,
        ClientName = s.ClientName,
        AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
        ClientSecrets = { new Secret(s.ClientSecret.Sha256()) },
        RedirectUris = { $"https://localhost:7501/signin-oidc" },
        PostLogoutRedirectUris = { "https://localhost:7501/signout-callback-oidc" },
        AllowedScopes = new List<string>
        {
            IdentityServerConstants.StandardScopes.OpenId,
            IdentityServerConstants.StandardScopes.Profile,
            IdentityServerConstants.StandardScopes.Email,
            s.Scope
        },
        AllowOfflineAccess = true,
    });
}
