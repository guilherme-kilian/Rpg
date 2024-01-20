using Cadof.Api.Configuration.Application;
using Cadof.Api.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddGeneralConfig(out var appSettings)
    .AddAuthenticationConfig()
    .AddApiConfig()
    .AddIdentityConfig(appSettings)
    .AddLoggingConfig()
    .AddDbConfig();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .AddApplicationConfig(appSettings)
    .Run();
