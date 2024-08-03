namespace Rpg.App.Web.Server.Configuration;

public static class ServiceConfig
{
    public static WebApplicationBuilder AddServicesConfig(this WebApplicationBuilder builder)
    {
        builder.AddLoggingConfig();

        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

        builder.AddAuthenticationConfig();

        return builder;
    }

}
