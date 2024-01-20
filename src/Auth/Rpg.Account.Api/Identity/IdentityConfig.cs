using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rpg.Account.Context;
using Rpg.Account.Models;

namespace Rpg.Account.Api.Identity;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        builder.Services.AddRazorPages();

        AddIdentityServer(builder, appSettings);

        return builder;
    }

    private static void AddIdentityServer(WebApplicationBuilder builder, AppSettings appSettings)
    {
         var profile = new IdentityProfile(appSettings.Identities);

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(profile.GetIdentityResources())
            .AddInMemoryApiScopes(profile.GetApiScopes())
            .AddInMemoryClients(profile.GetClients())
            .AddAspNetIdentity<ApplicationUser>();
    }
}
