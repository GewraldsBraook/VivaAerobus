using VivaAerobus.API.App_Start;
using Serilog;

try
{
    Log.Information("Starting API");

    Bootstrapper.BoostrapApi();
}
catch (Exception ex)
{
    Log.Error(ex, "Unhandled exception");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

return 0;