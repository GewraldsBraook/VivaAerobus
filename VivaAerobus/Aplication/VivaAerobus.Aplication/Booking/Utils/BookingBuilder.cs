namespace VivaAerobus.Aplication.Booking.Utils
{
    public static class BookingBuilder
    {
        public static Domain.Booking.Models.Booking GetDummyBooking(string recordLocator)
        {
            return new Domain.Booking.Models.Booking
            {
                RecordLocator = recordLocator,
                CreatedDate = DateTime.UtcNow
            };
        }
    }
}
