namespace VivaAerobus.Aplication.Booking.Services
{
    public interface IGetBookingsAppService
    {
        public IEnumerable<Domain.Booking.Models.Booking> Get();
    }
}
