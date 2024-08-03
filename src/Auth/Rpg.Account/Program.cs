using Rpg.Account.Configuration;
using Rpg.Account.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddGeneralConfig(out var appSettings)
    .AddIdentityConfig(appSettings);

var app = builder.Build();

app.UseSerilogRequestLogging();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages()
    .RequireAuthorization();

app.Run();
