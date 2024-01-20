using Cadof.Core.Exceptions;
using Cadof.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Cadof.Api.Configuration.Services;

public static class DbConfig
{
    public static WebApplicationBuilder AddDbConfig(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ConfigurationException("Empty connection string");
        builder.Services.AddDbContext<IDbContext, CadofContext>(opt => opt.UseSqlServer(connectionString));
        builder.Services.AddScoped<IDbContext, CadofContext>();

        return builder;
    }
}
