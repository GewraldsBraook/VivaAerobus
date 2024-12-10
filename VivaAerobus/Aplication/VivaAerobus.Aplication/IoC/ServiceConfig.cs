using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VivaAerobus.Aplication.Log.Services;
using VivaAerobus.Aplication.Log.Services.Impl;
using System.Reflection;

namespace VivaAerobus.Aplication.IoC
{
    public static class ServiceConfig
    {
        public static void ConfigureIoC(IServiceCollection services)
        {
            _ = services.AddMediatR(Assembly.GetExecutingAssembly());
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            _ = services.AddScoped<IGetLogsAppService, GetLogsAppService>();
        }
    }
}
