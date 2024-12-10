using Microsoft.Extensions.Logging;
using VivaAerobus.Domain.Repository;

namespace VivaAerobus.Aplication.Booking.Services.Impl
{
    public class CreateBookingAppService : ICreateBookingAppService
    {
        //TODO por temas de tiempo no fue posible hacer la implementacion del repositorio

        private readonly IRepository<Domain.Booking.Models.Booking> _repository;

        private readonly ILogger<CreateBookingAppService> _logger;

        public CreateBookingAppService(ILogger<CreateBookingAppService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Create(Domain.Booking.Models.Booking booking)
        {
            _logger.LogInformation($"Create booking {booking.RecordLocator} start");

            if (booking.CreatedDate == DateTime.MinValue) booking.CreatedDate = DateTime.UtcNow;

            _logger.LogInformation($"Create booking {booking.RecordLocator} end");
        }

        private void SaveBooking(Domain.Booking.Models.Booking booking)
        {
            try
            {
                _repository.Add(booking);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Booking {booking.RecordLocator}");
            }
        }
    }
}
