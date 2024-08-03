using Microsoft.EntityFrameworkCore;
using Rpg.Core.Exceptions;
using Rpg.Infra.Context;

namespace Rpg.Api.Configuration.Services;

public static class DbConfig
{
    public static WebApplicationBuilder AddDbConfig(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ConfigurationException("Empty connection string");
        builder.Services.AddDbContext<IDbContext, RpgContext>(opt => opt.UseSqlServer(connectionString));
        builder.Services.AddScoped<IDbContext, RpgContext>();

        return builder;
    }
}
