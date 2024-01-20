namespace Rpg.Account.Api.Configuration.Application;

public static class IdentityApplication
{
    public static WebApplication AddIdentityConfig(this WebApplication app, AppSettings appSettings)
    {
        return app;
    }
}
