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

var apiName = Assembly.GetEntryAssembly().GetName().Name;

var builder = WebApplication.CreateBuilder();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");

builder.Services
    .AddControllers()
    .AddControllersAsServices();

builder.Services.AddSwaggerGen()
    .RegisterGames();


builder.AddSerilogLogging();


var app = builder.Build();

app.UseSerilogRequestLogging();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
    });
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.MapControllers();

await app.RunAsync();