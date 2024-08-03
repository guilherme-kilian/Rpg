using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Rpg.App.Web.Server.Configuration;

public static class LoggingConfig
{
    public static WebApplicationBuilder AddLoggingConfig(this WebApplicationBuilder builder)
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

        return builder;
    }

    public static WebApplication AddLoggingConfig(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        return app;
    }
}
