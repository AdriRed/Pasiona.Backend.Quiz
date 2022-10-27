using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SocialGames.TechnicalTest.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SocialGames.TechnicalTest.IoC;

var apiName = Assembly.GetEntryAssembly().GetName().Name;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers()
                .AddControllersAsServices();

builder.Services.AddSwaggerGen();
builder.Services.RegisterGames();

var app = builder.Build();

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

app.Run();