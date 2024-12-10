using Microsoft.Extensions.Logging;
using VivaAerobus.Aplication.Booking.Utils;

namespace VivaAerobus.Aplication.Booking.Services.Impl
{
    public class GetBookingsAppService : IGetBookingsAppService
    {
        private readonly ILogger<GetBookingsAppService> _logger;

        public GetBookingsAppService(ILogger<GetBookingsAppService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<Domain.Booking.Models.Booking> Get()
        {
            try
            {
                _logger.LogInformation($"Get bookings start");

                var bookings = new List<Domain.Booking.Models.Booking>
                {
                    BookingBuilder.GetDummyBooking("AHG761"),
                    BookingBuilder.GetDummyBooking("HAG771"),
                    BookingBuilder.GetDummyBooking("JHG856")
                };

                _logger.LogInformation($"Get bookings end with {bookings.Count} records");

                return bookings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting all bookins");
                throw;
            }
        }
    }
}

