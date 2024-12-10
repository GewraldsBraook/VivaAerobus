using MediatR;
using VivaAerobus.Domain.CQRS.Models;
using VivaAerobus.Aplication.Booking.Models.Queries.Results;

namespace VivaAerobus.Aplication.Booking.Models.Queries
{
    public class GetBookingQuery : Query, IRequest<QueryResponse<BookingResult>>
    {
        public string RecordLocator { get; set; }
    }
}
