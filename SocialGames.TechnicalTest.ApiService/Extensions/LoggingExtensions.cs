using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Expressions;
using Serilog.Filters;
using Serilog.Templates;

namespace SocialGames.TechnicalTest.ApiService.Extensions;

public static class LoggingExtensions
{
    public static void AddSerilogLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders()
            .AddEventLog()
            .AddEventSourceLogger()
            .AddConfiguration(builder.Configuration);
            // .AddSerilog();

        builder.Host
            .UseSerilog((context, config) =>
                config.ReadFrom.Configuration(context.Configuration)
            )
            .UseConsoleLifetime(x => x.SuppressStatusMessages = false);
    }
}
