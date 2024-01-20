using Duende.IdentityServer.Services;

namespace Cadof.Api.Identity;

public class CorsPolicy : ICorsPolicyService
{
    public Task<bool> IsOriginAllowedAsync(string origin) => Task.FromResult(true);
}
