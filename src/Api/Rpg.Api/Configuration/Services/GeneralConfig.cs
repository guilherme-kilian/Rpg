using Cadof.Core.Exceptions;

namespace Cadof.Api.Configuration.Services;

public static class GeneralConfig
{
    public static WebApplicationBuilder AddGeneralConfig(this WebApplicationBuilder builder, out AppSettings appsettings)
    {
        builder.Configuration.AddEnvironmentVariables("Rpg_Api_");

        appsettings = builder.Configuration.GetRequiredSection(nameof(AppSettings)).Get<AppSettings>() ?? throw new ConfigurationException("Empty app settings");
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddHttpContextAccessor();
        return builder;
    }
}
