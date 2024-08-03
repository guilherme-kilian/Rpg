using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rpg.App.Web.Client.Bff;

namespace Rpg.App.Web.Client.Configuration;

public static class BffConfigs
{
    public static WebAssemblyHostBuilder AddBffConfigs(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddAuthorizationCore();
        builder.Services.AddScoped<AuthenticationStateProvider, BffAuthenticationStateProvider>();

        builder.Services.AddTransient<AntiforgeryHandler>();

        builder.Services.AddHttpClient("backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
            .AddHttpMessageHandler<AntiforgeryHandler>();

        builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));

        return builder;
    }
}
