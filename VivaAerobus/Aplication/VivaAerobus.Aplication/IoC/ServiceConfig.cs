using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VivaAerobus.Aplication.Booking.Services;
using VivaAerobus.Aplication.Booking.Services.Impl;

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
            _ = services.AddScoped<IGetBookingsAppService, GetBookingsAppService>();
            _ = services.AddScoped<IGetBookingAppService, GetBookingAppService>();
            _ = services.AddScoped<ICreateBookingAppService, CreateBookingAppService>();
        }
    }
}
