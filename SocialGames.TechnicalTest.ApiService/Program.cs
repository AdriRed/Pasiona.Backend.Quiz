using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SocialGames.TechnicalTest.ApiService.Extensions;
using SocialGames.TechnicalTest.ApiService.Middlewares;
using SocialGames.TechnicalTest.IoC;
using System.Globalization;
using System.IO;
using System.Reflection;

// for validation messages
var defaultCulture = new CultureInfo("en-EU");
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

var apiName = Assembly.GetEntryAssembly().GetName().Name;

var builder = WebApplication.CreateBuilder();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

builder.Services.AddSwaggerGen()
    .RegisterGames()
    .RegisterValidators()
    .AddControllers()
    .AddControllersAsServices();

builder.AddSerilogLogging();

var app = builder.Build();

app.UseRequestLocalization();
app.UseSerilogRequestLogging();

app.UseMiddleware<GlobalExceptionMiddleware>();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
    });
}

app.UseRouting();

app.MapControllers();

await app.RunAsync();