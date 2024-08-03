using Serilog;

namespace Rpg.Api.Configuration.Services;

public static class LoggingConfig
{
    public static WebApplicationBuilder AddLoggingConfig(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSerilog(log =>
            {
                log.Enrich.FromLogContext();
                log.WriteTo.Console();
            });
        return builder;
    }
}
