using MediatR;
using VivaAerobus.Aplication.Booking.Services;
using VivaAerobus.Aplication.Booking.Models.Queries;
using VivaAerobus.Aplication.Booking.Models.Queries.Results;
using VivaAerobus.Domain.CQRS.Models;

namespace VivaAerobus.Aplication.Booking.Handlers
{
    public class GetAllBookingHandler : IRequestHandler<GetBookingQuery, QueryResponse<BookingResult>>
    {
        private readonly IGetBookingAppService _getBookingAppService;

        public GetAllBookingHandler(IGetBookingAppService getBookingsAppService)
        {
            _getBookingAppService = getBookingsAppService ?? throw new ArgumentNullException(nameof(getBookingsAppService));
        }

        public Task<QueryResponse<BookingResult>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking = _getBookingAppService.Get(request.RecordLocator);
            var result = new BookingResult
            {
                Booking = booking,
            };

            return Task.FromResult(new QueryResponse<BookingResult> { Result = new ResponseObject<BookingResult>(true, result) });
        }
    }
}
