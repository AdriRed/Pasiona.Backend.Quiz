using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SocialGames.TechnicalTest.IoC;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using SocialGames.TechnicalTest.ApiService.Extensions;
using System.Globalization;
using SocialGames.TechnicalTest.ApiService.Middlewares;

// for validation messages
CultureInfo defaultCulture = new CultureInfo("en-EU");
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