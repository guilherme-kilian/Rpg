using Rpg.Account.Api.Configuration.Application;
using Rpg.Account.Api.Configuration.Services;
using Rpg.Account.Api.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddGeneralConfig(out var appSettings)
    .AddApiConfig()
    .AddIdentityConfig(appSettings);

var app = builder.Build();


app
    .AddApplicationConfig()
    .AddIdentityConfig(appSettings)
    .Run();
