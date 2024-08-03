using Rpg.App.Web.Server.Components;
using Rpg.App.Web.Server.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServicesConfig();

var app = builder.Build();

app.AddLoggingConfig();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseBff();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Rpg.App.Web.Client._Imports).Assembly);

app.MapBffManagementEndpoints();

app.Run();
