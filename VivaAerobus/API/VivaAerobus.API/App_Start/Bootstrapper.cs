using Microsoft.OpenApi.Models;
using Serilog;
using VivaAerobus.API.IoC;
using VivaAerobus.Aplication.Health.Impl;

namespace VivaAerobus.API.App_Start;

public static class Bootstrapper
{
    internal static void BoostrapApi()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        ServiceConfig.ConfigureIoC(builder.Services);
        ConfigureSeriLog(builder);
        ConfigureHttpServices(builder);
        ConfigureSwagger(builder);

        WebApplication app = builder.Build();

        ConfigureMiddelware(app);
        app.Services.GetRequiredService<ApiRunner>().Run(app);
    }

    internal static void ConfigureHttpServices(WebApplicationBuilder builder)
    {
        AddHealthChecks(builder);

        _ = builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();

        _ = builder.Services.AddCors(option => option.AddPolicy("corsApp", builder =>
        {
            _ = builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));

        _ = builder.Services.AddRouting(option =>
        {
            option.LowercaseUrls = true;
        });

    }

    private static void AddHealthChecks(WebApplicationBuilder builder)
    {
        _ = builder.Services.AddHealthChecks().AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck));
        _ = builder.Services.AddHealthChecksUI().AddInMemoryStorage();
    }

    internal static void ConfigureSwagger(WebApplicationBuilder builder)
    {
        _ = builder.Services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Name = "ApiKey",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "ApiKeyScheme",
                In = ParameterLocation.Header,
                Description = "ApiKey must appear in header"
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "ApiKey"
                        },
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
    }

    internal static void ConfigureSeriLog(WebApplicationBuilder builder)
    {
        _ = builder.Host.UseSerilog((hostContext, services, configuration) =>
        {
            configuration.ReadFrom.Configuration(hostContext.Configuration)
            .Enrich.WithThreadId().Enrich.WithThreadName();
        });
    }

    internal static void ConfigureMiddelware(WebApplication app)
    {
        //_ = app.UseMiddleware<ApiKeyMiddleware>();
        //_ = app.UseMiddleware<UnhandledErrorMiddleware>();
    }
}
