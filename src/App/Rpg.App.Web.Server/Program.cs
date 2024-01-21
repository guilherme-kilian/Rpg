using Rpg.App.Web.Server.Configuration.Application;
using Rpg.App.Web.Server.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServicesConfig();

var app = builder.Build();

app.AddApplicationConfig().Run();
