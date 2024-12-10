using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

namespace VivaAerobus.API.App_Start;

public class ApiRunner
{
    #region Private Fields

    private readonly ILogger<ApiRunner> _logger;

    #endregion Private Fields

    #region Public Constructors

    public ApiRunner(ILogger<ApiRunner> logger)
    {
        _logger = logger;
    }

    #endregion Public Constructors

    #region Public Methods

    public void Run(WebApplication app)
    {
        _ = new Mutex(true, nameof(ApiRunner), out bool createdInstance);

        if (createdInstance)
        {
            _logger.LogInformation("Starting API");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.MapHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config =>
            {
                config.UIPath = "/health-ui";
            });

            _ = app.UseSerilogRequestLogging();
            _ = app.UseHttpsRedirection();
            _ = app.UseAuthentication();
            _ = app.MapControllers();

            app.Run();
        }
        else
        {
            _logger.LogInformation("An instance is already running");
        }
    }

    #endregion Public Methods
}

