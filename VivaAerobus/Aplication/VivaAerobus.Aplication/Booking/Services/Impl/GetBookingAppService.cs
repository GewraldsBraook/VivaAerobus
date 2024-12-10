using Microsoft.Extensions.Logging;
using VivaAerobus.Aplication.Booking.Utils;

namespace VivaAerobus.Aplication.Booking.Services.Impl
{
    public class GetBookingAppService : IGetBookingAppService
    {
        private readonly ILogger<GetBookingAppService> _logger;

        public GetBookingAppService(ILogger<GetBookingAppService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Domain.Booking.Models.Booking Get(string recordLocator)
        {
            try
            {
                _logger.LogInformation($"Get booking {recordLocator} start");

                var booking = BookingBuilder.GetDummyBooking(recordLocator);

                _logger.LogInformation($"Get booking {recordLocator} end");

                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error get booking {recordLocator}");
                throw;
            }
        }
    }
}
