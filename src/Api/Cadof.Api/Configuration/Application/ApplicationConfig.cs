namespace Cadof.Api.Configuration.Application;

public static class ApplicationConfig
{
    public static WebApplication AddApplicationConfig(this WebApplication app, AppSettings appSettings)
    {
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseBff();

        app.MapBffManagementEndpoints();

        app.MapControllers();

        return app;
    }
}
