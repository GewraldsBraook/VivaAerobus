using MediatR;
using VivaAerobus.Domain.CQRS.Models;
using VivaAerobus.Aplication.Booking.Models.Queries.Results;

namespace VivaAerobus.Aplication.Booking.Models.Queries
{
    public class GetAllBookingsQuery : Query, IRequest<QueryResponse<BookingsResult>>
    {

    }
}
