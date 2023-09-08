using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;
using Serilog.Exceptions.EntityFrameworkCore.Destructurers;
using Serilog.Filters;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Samat.Framework.Endpoints.Web.Middlewares;

public static class Logging
{
    public static ILogger CreateLogger(string appName)
    {
        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        IConfiguration configuration = GetConfiguration();
        var loggerConfig = new LoggerConfiguration();
        string? elasticsearchUri = configuration["ConnectionStrings:ElasticConnectionString"];

        string? assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;

        loggerConfig
        .Enrich.FromLogContext()
        .Enrich.WithEnvironmentName()
            .Enrich.WithProperty("ApplicationName", appName)
            .Enrich.WithProperty("EnvironmentName", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
            .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
            .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
            .MinimumLevel.Override("System", LogEventLevel.Error)
            .MinimumLevel.Override("SAMAT", LogEventLevel.Debug)
             .Enrich.With<ActivityEnricher>()
            .Enrich.WithMachineName()
            .Enrich.WithProperty("Assembly", assemblyName);


        loggerConfig.Enrich.WithExceptionDetails(new DestructuringOptionsBuilder()
            .WithDefaultDestructurers()
            .WithDestructurers(new[] { new DbUpdateExceptionDestructurer() }));

        loggerConfig.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}");

        if (!string.IsNullOrWhiteSpace(elasticsearchUri))
        {
            loggerConfig.WriteTo.Logger(lc =>
                        lc.Filter.ByExcluding(Matching.WithProperty<bool>("Security", p => p))
                            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                            {
                                AutoRegisterTemplate = true,
                                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                                IndexFormat = $"{assemblyName!.ToLower().Replace(".", "-")}-{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                                BatchAction = ElasticOpType.Create,
                                TypeName = null,
                                InlineFields = true,
                                FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                            }))
                    .WriteTo.Logger(lc =>
                        lc.Filter.ByIncludingOnly(Matching.WithProperty<bool>("Security", p => p))
                            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUri))
                            {
                                AutoRegisterTemplate = true,
                                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                                IndexFormat = "security-{0:yyyy.MM.dd}",
                                BatchAction = ElasticOpType.Create,
                                InlineFields = true
                            }));
        }

        loggerConfig.ReadFrom.Configuration(configuration);

        return loggerConfig.CreateLogger();
    }
}