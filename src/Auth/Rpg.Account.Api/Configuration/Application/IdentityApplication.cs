using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Rpg.Account.Api.Configuration.Services;

namespace Rpg.Account.Api.Configuration.Application;

public static class IdentityApplication
{
    public static WebApplication AddIdentityConfig(this WebApplication app, AppSettings appSettings)
    {
        InitializeDatabase(app, appSettings);
        return app;
    }

    private static void InitializeDatabase(IApplicationBuilder app, AppSettings appSettings)
    {
        var profile = new IdentityProfile(appSettings.Identities);

        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();
            if (!context.Clients.Any())
            {
                foreach (var client in profile.GetClients())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in profile.GetResources())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiScopes.Any())
            {
                foreach (var resource in profile.GetApiScopes())
                {
                    context.ApiScopes.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }
    }
}
