using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Rpg.App.Web.Server.Configuration.Services;

public static class AuthenticationConfig
{
    public static WebApplicationBuilder AddServicesConfig(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) => lc
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            .MinimumLevel.Override("IdentityModel", LogEventLevel.Debug)
            .MinimumLevel.Override("Duende.Bff", LogEventLevel.Debug)
            .Enrich.FromLogContext()
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                theme: AnsiConsoleTheme.Code));

        builder.Services.AddControllers();

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
                options.Authority = "https://localhost:8003";

                options.ClientId = "bff";
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
