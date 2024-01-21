using Serilog;

namespace Rpg.App.Web.Server.Configuration.Application;

public static class ApplicationConfig
{
    public static WebApplication AddApplicationConfig(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
            app.UseWebAssemblyDebugging();
        else
            app.UseExceptionHandler("/Error");

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();
        app.UseBff();
        app.UseAuthorization();

        app.MapBffManagementEndpoints();
        app.MapRazorPages();

        app.MapControllers()
            .RequireAuthorization()
            .AsBffApiEndpoint();

        app.MapFallbackToFile("index.html");

        return app;
    }
}
