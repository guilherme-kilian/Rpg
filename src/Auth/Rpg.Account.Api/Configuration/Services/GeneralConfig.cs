namespace Rpg.Account.Api.Configuration.Services;

public static class GeneralConfig
{
    public static WebApplicationBuilder AddGeneralConfig(this WebApplicationBuilder builder, out AppSettings appsettings)
    {
        appsettings = builder.Configuration.GetRequiredSection(nameof(AppSettings)).Get<AppSettings>() ?? throw new ArgumentNullException("EmptyAppSettings");
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddHttpContextAccessor();
        return builder;
    }
}
