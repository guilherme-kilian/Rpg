using Cadof.Api.Identity;
using Cadof.Domain;
using Cadof.Infra.Context;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Cadof.Api.Configuration.Services;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        //AddIdentity(builder);
        AddIdentityServer(builder, appSettings);

        return builder;
    }

    private static void AddIdentity(WebApplicationBuilder builder)
    {
        builder.Services
                    .AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<CadofContext>();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
            options.Lockout.AllowedForNewUsers = true;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });
    }

    private static void AddIdentityServer(WebApplicationBuilder builder, AppSettings appSettings)
    {
        var migrationsAssembly = "Rpg.Infra";

        var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("ConnectionStringCanNotBeNull");

        builder.Services
            .AddIdentityServer()
            .AddConfigurationStore(options => options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                sql => sql.MigrationsAssembly(migrationsAssembly)))
            .AddOperationalStore(opt =>
            {
                opt.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddDeveloperSigningCredential();

        builder.Services.AddTransient<IProfileService, ProfileService>();
    }
}
