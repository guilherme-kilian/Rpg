namespace Rpg.App.Web.Back.Configuration.Application;

public static class ApplicationConfig
{
    public static WebApplication AddApplicationConfig(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseBff();
        app.UseAuthorization();

        app.MapBffManagementEndpoints();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("index.html");

        return app;
    }
}
