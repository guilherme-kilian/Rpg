using Rpg.Api.Configuration.Application;
using Rpg.Api.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddGeneralConfig(out var appSettings)
    .AddAuthenticationConfig()
    .AddApiConfig()
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
    .AddApplicationConfig()
    .Run();
