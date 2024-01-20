using Microsoft.IdentityModel.Tokens;

namespace Cadof.Api.Configuration.Services;

public static class AuthenticationConfig
{
    public static WebApplicationBuilder AddAuthenticationConfig(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            options.Authority = "https://localhost:7501";

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false
            };
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Api", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "api-rpg");
            });
        });

        return builder;
    }

}
