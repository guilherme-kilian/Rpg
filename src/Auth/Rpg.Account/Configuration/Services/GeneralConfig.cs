using Serilog;

namespace Rpg.Account.Api.Configuration.Services;

public static class GeneralConfig
{
    public static WebApplicationBuilder AddGeneralConfig(this WebApplicationBuilder builder, out AppSettings appsettings)
    {
        appsettings = builder.Configuration.GetRequiredSection(nameof(AppSettings)).Get<AppSettings>() ?? throw new ArgumentNullException("EmptyAppSettings");
        builder.Services.AddHttpContextAccessor();

        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(ctx.Configuration));

        return builder;
    }
}
