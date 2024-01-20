using Microsoft.IdentityModel.Tokens;

namespace Cadof.Api.Configuration.Services;

public static class AuthenticationConfig
{
    public static WebApplicationBuilder AddAuthenticationConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddBff();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "cookie";
            options.DefaultChallengeScheme = "oidc";
            options.DefaultSignOutScheme = "oidc";
        })
            .AddCookie("cookie", options =>
            {
                options.Cookie.Name = "__Host-blazor";
                options.Cookie.SameSite = SameSiteMode.Strict;
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:7501";

                options.ClientId = "api-rpg";
                options.ClientSecret = "batata123";
                options.ResponseType = "code";
                options.ResponseMode = "query";

                options.Scope.Add("openid");
                options.Scope.Add("profile");
                options.Scope.Add("api-rpg");
                options.Scope.Add("offline_access");

                options.MapInboundClaims = false;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
            });


        return builder;
    }

}
