using VivaAerobus.API.App_Start;

namespace VivaAerobus.API.IoC;

internal static class ServiceConfig
{
    internal static void ConfigureIoC(IServiceCollection services)
    {
        _ = services.AddSingleton<ApiRunner>();

        Aplication.IoC.ServiceConfig.ConfigureIoC(services);
    }
}
