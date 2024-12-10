using MediatR;
using VivaAerobus.Aplication.Booking.Models.Commands;
using VivaAerobus.Aplication.Booking.Services;
using VivaAerobus.Domain.CQRS.Models;

namespace VivaAerobus.Aplication.Booking.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, CommandResponse<object>>
    {
        private readonly ICreateBookingAppService _createBookingAppService;

        public CreateBookingHandler(ICreateBookingAppService createBookingAppService)
        {
            _createBookingAppService = createBookingAppService ?? throw new ArgumentNullException(nameof(createBookingAppService));
        }

        public Task<CommandResponse<object>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CommandResponse<object> { Result = new ResponseObject<object>(true, new object()) });
        }
    }
}
