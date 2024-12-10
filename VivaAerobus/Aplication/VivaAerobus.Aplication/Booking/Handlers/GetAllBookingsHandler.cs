using MediatR;
using VivaAerobus.Aplication.Booking.Services;
using VivaAerobus.Aplication.Booking.Models.Queries;
using VivaAerobus.Aplication.Booking.Models.Queries.Results;
using VivaAerobus.Domain.CQRS.Models;

namespace VivaAerobus.Aplication.Booking.Handlers
{
    public class GetAllBookingsHandler : IRequestHandler<GetAllBookingsQuery, QueryResponse<BookingsResult>>
    {
        private readonly IGetBookingsAppService _getBookingsAppService;

        public GetAllBookingsHandler(IGetBookingsAppService getBookingsAppService)
        {
            _getBookingsAppService = getBookingsAppService ?? throw new ArgumentNullException(nameof(getBookingsAppService));
        }

        public Task<QueryResponse<BookingsResult>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var bookings = _getBookingsAppService.Get();
            var result = new BookingsResult
            {
                Bookings = bookings,
            };

            return Task.FromResult(new QueryResponse<BookingsResult> { Result = new ResponseObject<BookingsResult>(true, result) });
        }
    }
}
