using Microsoft.IdentityModel.Tokens;

namespace Cadof.Api.Configuration.Services;

public static class AuthenticationConfig
{
    public static WebApplicationBuilder AddAuthenticationConfig(this WebApplicationBuilder builder)
    {
        //builder.Services.AddAuthentication("Bearer")
        //    .AddJwtBearer("Bearer", options =>
        //    {
        //        options.Authority = "https://localhost:7047";

        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateAudience = false,
        //        };
        //    });

        return builder;
    }

}
