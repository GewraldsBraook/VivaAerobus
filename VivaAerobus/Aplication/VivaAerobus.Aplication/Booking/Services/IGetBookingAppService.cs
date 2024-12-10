namespace VivaAerobus.Aplication.Booking.Services
{
    public interface IGetBookingAppService
    {
        public Domain.Booking.Models.Booking Get(string recordLocator);
    }
}
