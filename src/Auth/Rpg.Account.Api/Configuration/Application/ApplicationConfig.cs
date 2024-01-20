namespace Rpg.Account.Api.Configuration.Application;

public static class ApplicationConfig
{
    public static WebApplication AddApplicationConfig(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseIdentityServer();

        app.MapControllers();

        return app;
    }
}
