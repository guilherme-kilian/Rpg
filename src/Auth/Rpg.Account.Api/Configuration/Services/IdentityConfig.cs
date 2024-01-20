using Microsoft.EntityFrameworkCore;

namespace Rpg.Account.Api.Configuration.Services;

public static class IdentityConfig
{
    public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        AddIdentityServer(builder, appSettings);

        return builder;
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
    }
}
